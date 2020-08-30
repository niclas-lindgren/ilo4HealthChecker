namespace iloHealthChecker.Contracts
{

    public class HealthSummaryResponse
    {
        public readonly StatusTypes ams_Ready;
        public readonly StatusTypes battery_Status;
        public readonly StatusTypes cpu_Status;
        public readonly StatusTypes ext_Hlth_Status;
        public readonly StatusTypes fans_Redundancy;
        public readonly StatusTypes fans_Status;
        public readonly StatusTypes hostpwr_State;
        public readonly int in_Post;
        public readonly StatusTypes mem_Status;
        public readonly StatusTypes nic_Status;
        public readonly int power_Supplies_Mismatch;
        public readonly StatusTypes power_Supplies_Redundancy;
        public readonly StatusTypes power_Supplies_Status;
        public readonly StatusTypes storage_Status;
        public readonly StatusTypes system_Health;
        public readonly StatusTypes temperature_Status;

        public HealthSummaryResponse(
            StatusTypes ams_ready,
          StatusTypes battery_status,
         StatusTypes cpu_status,
          StatusTypes ext_hlth_status,
          StatusTypes fans_redundancy,
          StatusTypes fans_status,
          StatusTypes hostpwr_state,
            int in_post,
          StatusTypes mem_status,
          StatusTypes nic_status,
            int power_supplies_mismatch,
           StatusTypes power_supplies_redundancy,
          StatusTypes power_supplies_status,
          StatusTypes storage_status,
          StatusTypes system_health,
           StatusTypes temperature_status
        )
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
        public override string ToString()
        {
            return $"<table><tr><td>temperature status</td><td>{temperature_Status == StatusTypes.OP_STATUS_OK}</td></tr></table>";
        }
    }
}