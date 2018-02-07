using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Database;
using Microsoft.Practices.EnterpriseLibrary.Logging.Filters;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Portales.Api.Logs
{
    public class Logger
    {
        static LogWriter defaultWriter;
        DatabaseProviderFactory factory = new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection);
        LoggingConfiguration loggingConfiguration;

        public Logger()
        {
            DatabaseFactory.SetDatabaseProviderFactory(factory, false);
            loggingConfiguration = BuildProgrammaticConfig();
            defaultWriter = new LogWriter(loggingConfiguration);
        }

        private LoggingConfiguration BuildProgrammaticConfig()
        {
            TextFormatter extendedFormatter = new TextFormatter("Timestamp: {timestamp}{newline}Message: {message}{newline}Category: {category}{newline}Priority: {priority}{newline}EventId: {eventid}{newline}Severity: {severity}{newline}Title: {title}{newline}Activity ID: {property(ActivityId)}{newline}Machine: {localMachine}{newline}App Domain: {localAppDomain}{newline}ProcessId: {localProcessId}{newline}Process Name: {localProcessName}{newline}Thread Name: {threadName}{newline}Win32 ThreadId:{win32ThreadId}{newline}Extended Properties: {dictionary({key} - {value}{newline})}");

            // Category Filters
            ICollection<string> categories = new List<string>();
            categories.Add("BlockedByFilter");

            // Log Filters
            var priorityFilter = new PriorityFilter("Priority Filter", 2, 99);
            var logEnabledFilter = new LogEnabledFilter("LogEnabled Filter", true);
            var categoryFilter = new CategoryFilter("Category Filter", categories, CategoryFilterMode.AllowAllExceptDenied);

            // Trace Listeners
            var databaseTraceListener = new FormattedDatabaseTraceListener(DatabaseFactory.CreateDatabase("ExampleDatabase"), "WriteLog", "AddCategory", extendedFormatter);

            // Build Configuration
            var config = new LoggingConfiguration();
            config.Filters.Add(priorityFilter);
            config.Filters.Add(logEnabledFilter);
            config.Filters.Add(categoryFilter);
            config.AddLogSource("Database", SourceLevels.All, true).AddTraceListener(databaseTraceListener);

            return config;
        }

        [Description("Sending log entries to a database")]
        public void LogToDatabase()
        {
            // Check if logging is enabled before creating log entries.
            if (defaultWriter.IsLoggingEnabled())
            {
                // Create a Dictionary of extended properties
                Dictionary<string, object> exProperties = new Dictionary<string, object>();
                exProperties.Add("Extra Information", "Some Special Value");
                // Create a LogEntry using the constructor parameters. 
                defaultWriter.Write("Log entry with category, priority, event ID, severity, title, and extended properties.", "Database",
                    5, 9008, TraceEventType.Warning, "Logging Block Examples", exProperties);

                // Create a LogEntry using the constructor parameters. 
                LogEntry entry = new LogEntry("LogEntry with category, priority, event ID, severity, title, and extended properties.", "Database",
                    8, 9009, TraceEventType.Error, "Logging Block Examples", exProperties);
                defaultWriter.Write(entry);
            }
        }
    }
}