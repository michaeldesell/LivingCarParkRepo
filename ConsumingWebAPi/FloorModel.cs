using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace WebApiModels
{
    [DataContract]
    public class FloorModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }
        [DataMember(Name = "Floornumber")]
        public int Floornumber { get; set; }
        [DataMember(Name = "Spaces")]
        public int spaces { get; set; }
                
    }
}
