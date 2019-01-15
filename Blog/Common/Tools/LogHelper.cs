using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Common.Tools
{
    public class LogHelper
    {
        private static object objLock = new object();
        private static LogHelper instance = null;
        private string logPath_root;
        private string logPath_debug;
        private string logPath_exception;
        private string logPath_exceptionUnhandled;
        private string logPath_trace;
        private string logPath_web;
        private DateTime date;
        private LogHelper()
        {
            Init();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            date = DateTime.Now;
            logPath_root = AppSettings.GetConfig("Logconfigs:root");
            logPath_debug = AppSettings.GetConfig("Logconfigs:debug");
            logPath_exception = AppSettings.GetConfig("Logconfigs:exception");
            logPath_exceptionUnhandled = AppSettings.GetConfig("Logconfigs:exceptionUnhandled");
            logPath_trace = AppSettings.GetConfig("Logconfigs:trace");
            logPath_web = AppSettings.GetConfig("Logconfigs:web");
            if (string.IsNullOrEmpty(logPath_root))
            {
                //rootPath is unconfiged,use default path
                var monitor = System.IO.Directory.GetCurrentDirectory();
                logPath_root = System.IO.Path.Combine(monitor, "Log");
            }
            logPath_debug = string.IsNullOrEmpty(logPath_debug) ? System.IO.Path.Combine(logPath_root, @"Debug") : logPath_debug;
            logPath_exception = string.IsNullOrEmpty(logPath_exception) ? System.IO.Path.Combine(logPath_root, @"Exception") : logPath_exception;
            logPath_exceptionUnhandled = string.IsNullOrEmpty(logPath_exceptionUnhandled) ? System.IO.Path.Combine(logPath_root, @"ExceptionUnhandled") : logPath_exceptionUnhandled;
            logPath_trace = string.IsNullOrEmpty(logPath_trace) ? System.IO.Path.Combine(logPath_root, @"Trace") : logPath_trace;
            logPath_web = string.IsNullOrEmpty(logPath_web) ? System.IO.Path.Combine(logPath_root, @"Web") : logPath_web;
            CreateDirectory(logPath_debug);
            CreateDirectory(logPath_exception);
            CreateDirectory(logPath_exceptionUnhandled);
            CreateDirectory(logPath_trace);
            CreateDirectory(logPath_web);
        }

        /// <summary>
        /// 创建日志文件夹
        /// </summary>
        /// <param name="path"></param>
        private void CreateDirectory(string path)
        {
            try
            {
#if DEBUG
                Console.WriteLine($"创建日志文件路径{path}");
#endif
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(path, date.Year.ToString(), date.Month.ToString()));

            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.StackTrace);
#endif
            }
        }

        #region Write2LogFile
        public static bool WriteLogDebug(string debugString)
        {
            var instance = GetInstance();
            return instance.WriteLogCommon(instance.logPath_debug, debugString);
        }
        public static bool WriteLogException(string exceptionString)
        {
            var instance = GetInstance();
            return instance.WriteLogCommon(instance.logPath_exception, exceptionString);
        }
        public static bool WriteLogException(Exception ex)
        {
            var instance = GetInstance();
            return instance.WriteLogCommon(instance.logPath_exception, ex.ToString());
        }
        public static bool WriteLogExceptionUnhandled(string exceptionUnhandledString)
        {
            var instance = GetInstance();
            return instance.WriteLogCommon(instance.logPath_debug, exceptionUnhandledString);
        }
        public static bool WriteLogTrace(string traceString)
        {
            var instance = GetInstance();
            return instance.WriteLogCommon(instance.logPath_trace, traceString);
        }
        public static bool WriteLogWeb(string webString)
        {
            var instance = GetInstance();
            return instance.WriteLogCommon(instance.logPath_web, webString);
        }
        #endregion

        private bool WriteLogCommon(string logPath, string LogString)
        {
            var logFilename = System.IO.Path.Combine(logPath,date.Year.ToString(),date.Month.ToString(), date.ToString("yyyy-MM-dd") + ".txt");
#if DEBUG
            Console.WriteLine($"待写入日志文件路径{logFilename}");
#endif
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            sb.Append(DateTime.Now.ToString("HH:mm:ss:ffff"));
            sb.Append(']');
            sb.Append(LogString);
            try
            {
                if (!System.IO.File.Exists(logFilename))
                {
                    using(System.IO.FileStream fs=new System.IO.FileStream(logFilename, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite))
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fs))
                        {
                            sw.WriteLine(sb.ToString());
                            sw.Close();
                        }
                        fs.Close();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine($"写日志异常{ex.StackTrace}");
#endif
                return false;
            }
        }
        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns></returns>
        public static LogHelper GetInstance()
        {
            if (instance == null)
            {
                lock (objLock)
                {
                    if (instance == null)
                    {
                        instance = new LogHelper();
                    }
                }
            }
            return instance;
        }
    }
}
