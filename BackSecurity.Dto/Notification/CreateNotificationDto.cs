using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BackSecurity.Dto.Dto;
using Newtonsoft.Json;

namespace BackSecurity.Dto.Notification
{
    public class CreateNotificationDto
    {
        public int? Id { get; set; }
        public class DestinationNotification
        {

            [Required]
            public int Rut { get; set; }

            public string Userlogin { get; set; }
        }


        public enum NotificationType
        {

            CONTACT_REQUEST,

            ABSENCE_REQUEST,

            NOT_AVAILABLE_REQUEST,

            TURN,

            EXPIRE_CERTIFICATE,

            EXPIRE_FUNCTION
        }

        public class Request
        {
            [Required]

            public NotificationType Type { get; set; }

            [Required]
            public int Identifier { get; set; }

            public string Icon { get; set; }

            public string Level { get; set; }
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        public List<DestinationNotification> Destinations { get; set; }
        public AttachedDto AttachedDto { get; set; }
        public int? AttachedId { get; set; }
        public List<int> TipoContratosId { get; set; }
        public List<int> FunctionsId { get; set; }
        public int? FunctionId { get; set; }
        public int? TipoContratoId { get; set; }

        public DateTime? PlanDate { get; set; }

        public Request RequestData { get; set; }
        public string State { get; set; }
    }
}