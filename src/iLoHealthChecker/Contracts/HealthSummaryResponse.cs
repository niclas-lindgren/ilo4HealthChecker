using System.Collections.Generic;
namespace iloHealthChecker.Contracts
{

    public class HealthSummaryResponse
    {
        public readonly string ams_Ready;
        public readonly string battery_Status;
        public readonly string cpu_Status;
        public readonly string ext_Hlth_Status;
        public readonly string fans_Redundancy;
        public readonly string fans_Status;
        public readonly string hostpwr_State;
        public readonly int in_Post;
        public readonly string mem_Status;
        public readonly string nic_Status;
        public readonly int power_Supplies_Mismatch;
        public readonly string power_Supplies_Redundancy;
        public readonly string power_Supplies_Status;
        public readonly string storage_Status;
        public readonly string system_Health;
        public readonly string temperature_Status;

        public HealthSummaryResponse(string ams_ready,
                                     string battery_status,
                                     string cpu_status,
                                     string ext_hlth_status,
                                     string fans_redundancy,
                                     string fans_status,
                                     string hostpwr_state,
                                     int in_post,
                                     string mem_status,
                                     string nic_status,
                                     int power_supplies_mismatch,
                                     string power_supplies_redundancy,
                                     string power_supplies_status,
                                     string storage_status,
                                     string system_health,
                                     string temperature_status)
        {
            ams_Ready = ams_ready;
            battery_Status = battery_status;
            cpu_Status = cpu_status;
            ext_Hlth_Status = ext_hlth_status;
            fans_Redundancy = fans_redundancy;
            fans_Status = fans_status;
            hostpwr_State = hostpwr_state;
            in_Post = in_post;
            mem_Status = mem_status;
            nic_Status = nic_status;
            power_Supplies_Mismatch = power_supplies_mismatch;
            power_Supplies_Redundancy = power_supplies_redundancy;
            power_Supplies_Status = power_supplies_status;
            storage_Status = storage_status;
            system_Health = system_health;
            temperature_Status = temperature_status;
        }

        public static readonly List<string> okStatuses = new List<string>(){
            "OP_STATUS_OK", "OP_STATUS_ABSENT", "NOT_APPLICABLE", "ON", "AMS_UNAVAILABLE"
        };
    }
}