using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BackSecurity.Constants.Constants
{

    /* public static class RoleConstants
     {
         #region UserSolicitudeController
         public const string UserSolCreate = "WADM_USOL_CREATE";
         public const string UserSolReadAll = "WADM_USOL_READALL";
         public const string UserSolExportAll = "WADM_USOL_EXPORT_ALL";
         public const string UserSolReadMovil = "WADM_USOL_READMOVIL";
         public const string UserSolEdit = "WADM_USOL_EDIT";
         public const string UserSolDelete = "WADM_USOL_DELETE";
         #endregion

        #region LogoController
        public const string LogoCreate = "WADM_LOGO_CREATE";
        public const string LogoReadAll = "WADM_LOGO_READALL";
        public const string LogoGetById = "WADM_LOGO_GETBYID";
        public const string LogoGetByParam = "WADM_LOGO_GETBYPARAM";
        public const string LogoExportAll = "WADM_LOGO_EXPORT";
        public const string LogoEdit = "WADM_LOGO_EDIT";
        public const string LogoDelete = "WADM_LOGO_DELETE";
        public const string LogoVigente = "WADM_LOGO_VIGENTE";
        #endregion

          #region ModuleController
        public const string ModuleCreate = "WADM_Module_CREATE";
        public const string ModuleReadAll = "WADM_Module_READALL";
        public const string ModuleGetById = "WADM_Module_GETBYID";
        public const string ModuleUpdate = "WADM_Module_UPDATE";
        public const string ModuleDelete = "WADM_Module_DELETE";
        #endregion

        #region ReasonSolicitudeController
        public const string ReasonSolicitudeCreate = "WADM_ReasonSolicitude_CREATE";
        public const string ReasonSolicitudeReadAll = "WADM_ReasonSolicitude_READALL";
        public const string ReasonSolicitudeGetById = "WADM_ReasonSolicitude_GETBYID";
        public const string ReasonSolicitudeInsert = "WADM_ReasonSolicitude_INSERT";
        public const string ReasonSolicitudeUpdate = "WADM_ReasonSolicitude_UPDATE";
        public const string ReasonSolicitudeExport = "WADM_ReasonSolicitude_EXPORT";
        #endregion

        #region TurnController
        public const string TurnGet = "WADM_Turn_GET";
        public const string TurnHistory = "WADM_Turn_GETHISTORY";
        public const string TurnGetAll = "WADM_Turn_GETALL";
        #endregion

        #region WorkerAttendanceController
        public const string workerAttendance = "WADM_WorkerAttendance_GET";
        #endregion

        #region UnavabilitySolicitudeController
        public const string UnavabilitySolicitudeCreate = "WADM_UnavabilitySolicitude_CREATE";
        public const string UnavabilitySolicitudeListAll = "WADM_UnavabilitySolicitude_LISTALL";
        public const string UnavabilitySolicitudeGetById = "WADM_UnavabilitySolicitude_GETBYID";
        public const string UnavabilitySolicitudeDelete = "WADM_UnavabilitySolicitude_DELETE";
        public const string UnavabilitySolicitudeUpdate = "WADM_UnavabilitySolicitude_UPDATE";
        public const string UnavabilitySolicitudeExport = "WADM_UnavabilitySolicitude_EXPORT";
        public const string UnavabilitySolicitudeListMovil = "WADM_UnavabilitySolicitude_LISTMOVIL";
        public const string UnavabilitySolicitudeGetAllMotive = "WADM_UnavabilitySolicitude_GETALLMOTIVE";
        public const string UnavabilitySolicitudeGetFlow = "WADM_UnavabilitySolicitude_GETFLOW";
        #endregion        

        #region TypeLogoController
        public const string TypeLogoInsert = "WADM_TypeLogo_CREATE";
        public const string TypeLogoListAll = "WADM_TypeLogo_LIST";
        public const string TypeLogoGetById = "WADM_TypeLogo_GETBYID";
        public const string TypeLogoDelete = "WADM_TypeLogo_DELETE";
        public const string TypeLogoUpdate = "WADM_TypeLogo_UPDATE";
        #endregion
        #region NewsController
        public const string NewsCreate = "WADM_NEWS_CREATE";
        public const string NewsReadAll = "WADM_NEWS_READALL";
        public const string NewsGetById = "WADM_NEWS_GETBYID";
        public const string NewsInsert = "WADM_NEWS_INSERT";
        public const string NewsEdit = "WADM_NEWS_UPDATE";
        public const string NewsExport = "WADM_NEWS_EXPORT";
        public const string NewsDelete = "WADM_NEWS_DELETE"
        #endregion
        
        #region AccountController
        public const string AccountGetByRut = "WADM_ACCOUNT_GETBYRUT"
        public const string AccountGetPermissionsByRut = "WADM_ACCOUNT_GET_PERMISBYRUT"
        #endregion

         #region ActiveModuleController
         public const string ActiveCreate = "WADM_ActiveModule_GETBYRUT";
        public const string ActiveReadAll = "WADM_ActiveModule_GETBYRUT";
        public const string ActiveInsert = "WADM_ActiveModule_GETBYRUT";
        public const string ActiveEdit = "WADM_ActiveModule_GETBYRUT";
        public const string ActiveDelete = "WADM_ActiveModule_GETBYRUT";
        #endregion

        #region AttachedController
        public const string AttachedReadAll = "WADM_Attached_GETBYRUT";
        public const string AttachedGetById = "WADM_Attached_GETBYRUT";
        public const string AttachedInsert = "WADM_Attached_GETBYRUT";
        public const string AttachedEdit = "WADM_Attached_GETBYRUT";
        public const string AttachedDelete = "WADM_Attached_GETBYRUT";
        #endregion

        #region CancelShiftSolicitudeController
        public const string CancelShiftSolicitudeReadAll = "WADM_CancelShiftSolicitude_GETBYRUT";
        public const string CancelShiftSolicitudeGetById = "WADM_CancelShiftSolicitude_GETBYRUT";
        public const string CancelShiftSolicitudeInsert = "WADM_CancelShiftSolicitude_GETBYRUT";
        public const string CancelShiftSolicitudeEdit = "WADM_CancelShiftSolicitude_GETBYRUT";
        public const string CancelShiftSolicitudeExport = "WADM_CancelShiftSolicitude_GETBYRUT";
        public const string CancelShiftSolicitudeDelete = "WADM_CancelShiftSolicitude_GETBYRUT";
        #endregion

        #region ContactTypeController
        public const string ContactTypeGetById = "WADM_ContactType_GETBYRUT";
        #endregion

        #region FlowsController
        public const string FlowsGetById = "WADM_Flows_GETBYRUT";
        #endregion

        #region ImageController
        public const string ImageInsert = "WADM_Image_GETBYRUT";
        #endregion

        #region MessageModuleController
        public const string MessageModuleReadAll = "WADM_MessageModule_GETBYRUT";
        public const string MessageModuleGetById = "WADM_MessageModule_GETBYRUT";
        public const string MessageModuleInsert = "WADM_MessageModule_GETBYRUT";
        public const string MessageModuleEdit = "WADM_MessageModule_GETBYRUT";
        public const string MessageModuleDelete = "WADM_MessageModule_GETBYRUT";
        #endregion

        #region MessageTypeController
        public const string MessageTypeReadAll = "WADM_MessageType_GETBYRUT";
        public const string MessageTypeGetById = "WADM_MessageType_GETBYRUT";
        public const string MessageTypeInsert = "WADM_MessageType_GETBYRUT";
        public const string MessageTypeEdit = "WADM_MessageType_GETBYRUT";
        #endregion
        
        #region ReasonCancelShiftController
        public const string ReasonCancelShiftReadAll = "WADM_ReasonCancelShift_GETBYRUT";
        public const string ReasonCancelShiftGetById = "WADM_ReasonCancelShift_GETBYRUT";
        public const string ReasonCancelShiftInsert = "WADM_ReasonCancelShift_GETBYRUT";
        public const string ReasonCancelShiftEdit = "WADM_ReasonCancelShift_GETBYRUT";
        public const string ReasonCancelShiftExport = "WADM_ReasonCancelShift_GETBYRUT";
        public const string ReasonCancelShiftDelete = "WADM_ReasonCancelShift_GETBYRUT";
        #endregion

        #region ReasonCancelshiftExceptionController
        public const string ReasonCancelshiftExceptionReadAll = "WADM_ReasonCancelshiftException_GETBYRUT";
        public const string ReasonCancelshiftExceptionGetById = "WADM_ReasonCancelshiftException_GETBYRUT";
        public const string ReasonCancelshiftExceptionInsert = "WADM_ReasonCancelshiftException_GETBYRUT";
        public const string ReasonCancelshiftExceptionEdit = "WADM_ReasonCancelshiftException_GETBYRUT";
        #endregion

        #region ReasonUnavailabilityController 
        public const string ReasonUnavailabilityReadAll = "WADM_ReasonUnavailability_GETBYRUT";
        public const string ReasonUnavailabilityGetById = "WADM_ReasonUnavailability_GETBYRUT";
        public const string ReasonUnavailabilityInsert = "WADM_ReasonUnavailability_GETBYRUT";
        public const string ReasonUnavailabilityEdit = "WADM_ReasonUnavailability_GETBYRUT";
        public const string ReasonUnavailabilityExport = "WADM_ReasonUnavailability_GETBYRUT";
        #endregion
          
        #region ReasonUnavExceptionController
        public const string ReasonUnavExceptionReadAll = "WADM_ReasonUnavException_GETBYRUT";
        public const string ReasonUnavExceptionGetById = "WADM_ReasonUnavException_GETBYRUT";
        public const string ReasonUnavExceptionInsert = "WADM_ReasonUnavException_GETBYRUT";
        public const string ReasonUnavExceptionEdit = "WADM_ReasonUnavException_GETBYRUT";
        public const string ReasonUnavExceptionDelete = "WADM_ReasonUnavException_GETBYRUT";
        #endregion

        #region ReasonUnAvExceptionPersonController
        public const string ReasonUnAvExceptionPersonReadAll = "WADM_ReasonUnAvExceptionPerson_GETBYRUT";
        public const string ReasonUnAvExceptionPersonGetById = "WADM_ReasonUnAvExceptionPerson_GETBYRUT";
        public const string ReasonUnAvExceptionPersonInsert = "WADM_ReasonUnAvExceptionPerson_GETBYRUT";
        public const string ReasonUnAvExceptionPersonEdit = "WADM_ReasonUnAvExceptionPerson_GETBYRUT";
        public const string ReasonUnAvExceptionPersonDelete = "WADM_ReasonUnAvExceptionPerson_GETBYRUT";
        #endregion

        #region ShiftChangeSolicitudeController
        public const string ShiftChangeSolicitudeCreate = "WADM_ShiftChangeSolicitude_GETBYRUT";
        public const string ShiftChangeSolicitudeReadAll = "WADM_ShiftChangeSolicitude_GETBYRUT";
        public const string ShiftChangeSolicitudeGetById = "WADM_ShiftChangeSolicitude_GETBYRUT";
        public const string ShiftChangeSolicitudeInsert = "WADM_ShiftChangeSolicitude_GETBYRUT";
        public const string ShiftChangeSolicitudeEdit = "WADM_ShiftChangeSolicitude_GETBYRUT";
        public const string ShiftChangeSolicitudeExport = "WADM_ShiftChangeSolicitude_GETBYRUT";
        public const string ShiftChangeSolicitudeDelete = "WADM_ShiftChangeSolicitude_GETBYRUT";
        #endregion

        #region ShiftChangeSolicitudeStateController
        public const string ShiftChangeSolicitudeStateReadAll = "WADM_ShiftChangeSolicitudeState_GETBYRUT";
        #endregion
        
        #region ShiftController
        public const string ShiftReadAll = "WADM_Shift_GETBYRUT";
        #endregion

        #region SindicatoController
        public const string SindicatoReadAll = "WADM_Sindicato_GETBYRUT";
        #endregion

        #region SolicitudeStateController
        public const string SolicitudeStateReadAll = "WADM_SolicitudeState_GETBYRUT";
        public const string SolicitudeStateGetById = "WADM_SolicitudeState_GETBYRUT";
        public const string SolicitudeStateInsert = "WADM_SolicitudeState_GETBYRUT";
        public const string SolicitudeStateEdit = "WADM_SolicitudeState_GETBYRUT";
        public const string SolicitudeStateDelete = "WADM_SolicitudeState_GETBYRUT";
        #endregion
     }*/


    public static class RoleConstants
    {
        #region UserSolicitudeController
        public const string UserSolCreate = "SGN_PORT_COMODIN";
        public const string UserSolReadAll = "SGN_PORT_COMODIN";
        public const string UserSolReadMovil = "SGN_PORT_COMODIN";
        public const string UserSolExportAll = "SGN_PORT_COMODIN";
        public const string UserSolEdit = "SGN_PORT_COMODIN";
        public const string UserSolDelete = "SGN_PORT_COMODIN";
        #endregion

        #region LogoController
        public const string LogoCreate = "SGN_PORT_COMODIN";
        public const string LogoReadAll = "SGN_PORT_COMODIN";
        public const string LogoGetById = "SGN_PORT_COMODIN";
        public const string LogoGetByParam = "SGN_PORT_COMODIN";
        public const string LogoExportAll = "SGN_PORT_COMODIN";
        public const string LogoEdit = "SGN_PORT_COMODIN";
        public const string LogoDelete = "SGN_PORT_COMODIN";
        public const string LogoVigente = "SGN_PORT_COMODIN";
        #endregion

        #region ModuleController
        public const string ModuleCreate = "SGN_PORT_COMODIN";
        public const string ModuleReadAll = "SGN_PORT_COMODIN";
        public const string ModuleGetById = "SGN_PORT_COMODIN";
        public const string ModuleUpdate = "SGN_PORT_COMODIN";
        public const string ModuleDelete = "SGN_PORT_COMODIN";
        #endregion

        #region ReasonSolicitudeController
        public const string ReasonSolicitudeCreate = "SGN_PORT_COMODIN";
        public const string ReasonSolicitudeReadAll = "SGN_PORT_COMODIN";
        public const string ReasonSolicitudeGetById = "SGN_PORT_COMODIN";
        public const string ReasonSolicitudeInsert = "SGN_PORT_COMODIN";
        public const string ReasonSolicitudeUpdate = "SGN_PORT_COMODIN";
        public const string ReasonSolicitudeExport = "SGN_PORT_COMODIN";
        #endregion

        #region TurnController
        public const string TurnGet = "SGN_PORT_COMODIN";
        public const string TurnHistory = "SGN_PORT_COMODIN";
        public const string TurnGetAll = "SGN_PORT_COMODIN";
        #endregion

        #region WorkerAttendanceController
        public const string workerAttendance = "SGN_PORT_COMODIN";
        #endregion

        #region UnavabilitySolicitudeController
        public const string UnavabilitySolicitudeCreate = "SGN_PORT_COMODIN";
        public const string UnavabilitySolicitudeListAll = "SGN_PORT_COMODIN";
        public const string UnavabilitySolicitudeGetById = "SGN_PORT_COMODIN";
        public const string UnavabilitySolicitudeDelete = "SGN_PORT_COMODIN";
        public const string UnavabilitySolicitudeUpdate = "SGN_PORT_COMODIN";
        public const string UnavabilitySolicitudeExport = "SGN_PORT_COMODIN";
        public const string UnavabilitySolicitudeListMovil = "SGN_PORT_COMODIN";
        public const string UnavabilitySolicitudeGetAllMotive = "SGN_PORT_COMODIN";
        public const string UnavabilitySolicitudeGetFlow = "SGN_PORT_COMODIN";
        #endregion
        #region TypeLogoController
        public const string TypeLogoInsert = "SGN_PORT_COMODIN";
        public const string TypeLogoListAll = "SGN_PORT_COMODIN";
        public const string TypeLogoGetById = "SGN_PORT_COMODIN";
        public const string TypeLogoDelete = "SGN_PORT_COMODIN";
        public const string TypeLogoUpdate = "SGN_PORT_COMODIN";
        #endregion

        #region NewsController
        public const string NewsCreate = "SGN_PORT_COMODIN";
        public const string NewsReadAll = "SGN_PORT_COMODIN";
        public const string NewsGetById = "SGN_PORT_COMODIN";
        public const string NewsInsert = "SGN_PORT_COMODIN";
        public const string NewsEdit = "SGN_PORT_COMODIN";
        public const string NewsExport = "SGN_PORT_COMODIN";
        public const string NewsDelete = "SGN_PORT_COMODIN";
        #endregion

        #region AccountController
        public const string AccountGetByRut = "SGN_PORT_COMODIN";
        public const string AccountGetPermissionsByRut = "SGN_PORT_COMODIN";
        #endregion

        #region ActiveModuleController
         public const string ActiveCreate = "SGN_PORT_COMODIN";
        public const string ActiveReadAll = "SGN_PORT_COMODIN";
        public const string ActiveInsert = "SGN_PORT_COMODIN";
        public const string ActiveEdit = "SGN_PORT_COMODIN";
        public const string ActiveDelete = "SGN_PORT_COMODIN";
        #endregion

        #region AttachedController
        public const string AttachedReadAll = "SGN_PORT_COMODIN";
        public const string AttachedGetById = "SGN_PORT_COMODIN";
        public const string AttachedInsert = "SGN_PORT_COMODIN";
        public const string AttachedEdit = "SGN_PORT_COMODIN";
        public const string AttachedDelete = "SGN_PORT_COMODIN";
        #endregion

        #region CancelShiftSolicitudeController
        public const string CancelShiftSolicitudeReadAll = "SGN_PORT_COMODIN";
        public const string CancelShiftSolicitudeGetById = "SGN_PORT_COMODIN";
        public const string CancelShiftSolicitudeInsert = "SGN_PORT_COMODIN";
        public const string CancelShiftSolicitudeEdit = "SGN_PORT_COMODIN";
        public const string CancelShiftSolicitudeExport = "SGN_PORT_COMODIN";
        public const string CancelShiftSolicitudeDelete = "SGN_PORT_COMODIN";
        #endregion

        #region ContactTypeController
        public const string ContactTypeGetById = "SGN_PORT_COMODIN";
        #endregion

        #region FlowsController
        public const string FlowsGetById = "SGN_PORT_COMODIN";
        #endregion

        #region ImageController
        public const string ImageInsert = "SGN_PORT_COMODIN";
        #endregion

        #region MessageModuleController
        public const string MessageModuleReadAll = "SGN_PORT_COMODIN";
        public const string MessageModuleGetById = "SGN_PORT_COMODIN";
        public const string MessageModuleInsert = "SGN_PORT_COMODIN";
        public const string MessageModuleEdit = "SGN_PORT_COMODIN";
        public const string MessageModuleDelete = "SGN_PORT_COMODIN";
        #endregion

        #region MessageTypeController
        public const string MessageTypeReadAll = "SGN_PORT_COMODIN";
        public const string MessageTypeGetById = "SGN_PORT_COMODIN";
        public const string MessageTypeInsert = "SGN_PORT_COMODIN";
        public const string MessageTypeEdit = "SGN_PORT_COMODIN";
        #endregion
        
        #region ReasonCancelShiftController
        public const string ReasonCancelShiftReadAll = "SGN_PORT_COMODIN";
        public const string ReasonCancelShiftGetById = "SGN_PORT_COMODIN";
        public const string ReasonCancelShiftInsert = "SGN_PORT_COMODIN";
        public const string ReasonCancelShiftEdit = "SGN_PORT_COMODIN";
        public const string ReasonCancelShiftExport = "SGN_PORT_COMODIN";
        public const string ReasonCancelShiftDelete = "SGN_PORT_COMODIN";
        #endregion

        #region ReasonCancelshiftExceptionController
        public const string ReasonCancelshiftExceptionReadAll = "SGN_PORT_COMODIN";
        public const string ReasonCancelshiftExceptionGetById = "SGN_PORT_COMODIN";
        public const string ReasonCancelshiftExceptionInsert = "SGN_PORT_COMODIN";
        public const string ReasonCancelshiftExceptionEdit = "SGN_PORT_COMODIN";
        #endregion

        #region ReasonUnavailabilityController       
        public const string ReasonUnavailabilityReadAll = "SGN_PORT_COMODIN";
        public const string ReasonUnavailabilityGetById = "SGN_PORT_COMODIN";
        public const string ReasonUnavailabilityInsert = "SGN_PORT_COMODIN";
        public const string ReasonUnavailabilityEdit = "SGN_PORT_COMODIN";
        public const string ReasonUnavailabilityExport = "SGN_PORT_COMODIN";
        #endregion
          
        #region ReasonUnavExceptionController
        public const string ReasonUnavExceptionReadAll = "SGN_PORT_COMODIN";
        public const string ReasonUnavExceptionGetById = "SGN_PORT_COMODIN";
        public const string ReasonUnavExceptionInsert = "SGN_PORT_COMODIN";
        public const string ReasonUnavExceptionEdit = "SGN_PORT_COMODIN";
        public const string ReasonUnavExceptionDelete = "SGN_PORT_COMODIN";
        #endregion

        #region ReasonUnAvExceptionPersonController
        public const string ReasonUnAvExceptionPersonReadAll = "SGN_PORT_COMODIN";
        public const string ReasonUnAvExceptionPersonGetById = "SGN_PORT_COMODIN";
        public const string ReasonUnAvExceptionPersonInsert = "SGN_PORT_COMODIN";
        public const string ReasonUnAvExceptionPersonEdit = "SGN_PORT_COMODIN";
        public const string ReasonUnAvExceptionPersonDelete = "SGN_PORT_COMODIN";
        #endregion

        #region ShiftChangeSolicitudeController
        public const string ShiftChangeSolicitudeCreate = "SGN_PORT_COMODIN";
        public const string ShiftChangeSolicitudeReadAll = "SGN_PORT_COMODIN";
        public const string ShiftChangeSolicitudeGetById = "SGN_PORT_COMODIN";
        public const string ShiftChangeSolicitudeInsert = "SGN_PORT_COMODIN";
        public const string ShiftChangeSolicitudeEdit = "SGN_PORT_COMODIN";
        public const string ShiftChangeSolicitudeExport = "SGN_PORT_COMODIN";
        public const string ShiftChangeSolicitudeDelete = "SGN_PORT_COMODIN";
        #endregion

        #region ShiftChangeSolicitudeStateController
        public const string ShiftChangeSolicitudeStateReadAll = "SGN_PORT_COMODIN";
        #endregion
        
        #region ShiftController
        public const string ShiftReadAll = "SGN_PORT_COMODIN";
        #endregion

        #region SindicatoController
        public const string SindicatoReadAll = "SGN_PORT_COMODIN";
        #endregion

        #region SolicitudeStateController
        public const string SolicitudeStateReadAll = "SGN_PORT_COMODIN";
        public const string SolicitudeStateGetById = "SGN_PORT_COMODIN";
        public const string SolicitudeStateInsert = "SGN_PORT_COMODIN";
        public const string SolicitudeStateEdit = "SGN_PORT_COMODIN";
        public const string SolicitudeStateDelete = "SGN_PORT_COMODIN";
        #endregion

        #region AlertaController
        public const string AlertaCreate = "SGN_PORT_COMODIN";
        public const string AlertaReadAll = "SGN_PORT_COMODIN";
        public const string AlertaGetById = "SGN_PORT_COMODIN";
        public const string AlertaExportAll = "SGN_PORT_COMODIN";
        public const string AlertaEdit = "SGN_PORT_COMODIN";
        public const string AlertaDelete = "SGN_PORT_COMODIN";
        #endregion 
        #region CertificateController
        public const string CertificateReadAll = "SGN_PORT_COMODIN";
        #endregion
    }
}
