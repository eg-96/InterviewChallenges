using System;
using System.Collections.Generic;
using System.Linq;

class DefectiveServers
{
    public static List<int> FindDefectiveServersLinq(int[][] serverStatus)
    {
        List<int> defectiveServers = new List<int>();

        defectiveServers = serverStatus
            .Select((status, index) => new { status, index })
            .Where(server => server.status.All(s => s == 0))
            .Select(server => server.index)
            .ToList();

        return defectiveServers;
    }

    public static List<int> FindDefectiveServers(int[][] serverStatus)
    {
        List<int> defectiveServers = new List<int>();
        
        for (int i = 0; i < serverStatus.Length; i++)
        {
            bool isDefective = true;
            for (int j = 0; j < serverStatus[i].Length; j++)
            {
                if (serverStatus[i][j] == 1)
                {
                    isDefective = false;
                    break;
                }
            }
            if (isDefective)
            {
                defectiveServers.Add(i);
            }
        }
        
        return defectiveServers;
    }

    static void Main(string[] args)
    {
        int[][] serverStatus = new int[][]
        {
            new int[] {1, 0, 1, 1},
            new int[] {0, 0, 0, 0},
            new int[] {1, 1, 1, 1},
            new int[] {0, 0, 0, 0}
        };

        List<int> defectiveServers = FindDefectiveServers(serverStatus);

        Console.WriteLine("Defective Servers:");
        foreach (int server in defectiveServers)
        {
            Console.WriteLine(server);
        }
    }
}
