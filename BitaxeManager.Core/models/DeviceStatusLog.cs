namespace BitaxeManager.Core.models
{
    public class DeviceStatusLog
    {
        public int Id { get; set; }                      
        public DateTime Timestamp { get; set; }         
        public double HashRate { get; set; }            
        public float Temperature { get; set; }          
        public int SharesAccepted { get; set; }      
        public int FanSpeed { get; set; }
        public int FanRPM { get; set; }
    }
}
