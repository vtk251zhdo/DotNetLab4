using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLab4_ProcessManager
{
    public class ProcessInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long MemoryBytes { get; set; }
        public DateTime? StartTime { get; set; }
        public ProcessPriorityClass? Priority { get; set; }
        public int ThreadCount { get; set; }
    }

    public class ProcessService
    {
        public IEnumerable<ProcessInfoDto> GetProcesses()
        {
            var list = new List<ProcessInfoDto>();

            foreach (var proc in Process.GetProcesses())
            {
                DateTime? start = null;
                ProcessPriorityClass? priority = null;

                try { start = proc.StartTime; } catch { }
                try { priority = proc.PriorityClass; } catch { }

                list.Add(new ProcessInfoDto
                {
                    Id = proc.Id,
                    Name = proc.ProcessName,
                    MemoryBytes = proc.WorkingSet64,
                    StartTime = start,
                    Priority = priority,
                    ThreadCount = proc.Threads.Count
                });
            }

            return list;
        }

        public void KillProcess(int pid)
        {
            var proc = Process.GetProcessById(pid);
            proc.Kill();
        }

        public void SetPriority(int pid, ProcessPriorityClass priority)
        {
            var proc = Process.GetProcessById(pid);
            proc.PriorityClass = priority;
        }

        public void StartCalculator()
        {
            Process.Start("calc.exe");
        }

        public void StartWord()
        {
            Process.Start("winword.exe");
        }

        public void StartApp(string path)
        {
            Process.Start(path);
        }
    }
}
