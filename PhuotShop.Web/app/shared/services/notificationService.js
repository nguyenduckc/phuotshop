(function (app) {
    app.service('notificationService', notificationService);

    function notificationService() {
        toastr.option = {
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "fadeIn": 300,
            "fadeOut": 1000,
            "timeOut": 3000,
            "extendedTimeOut": 1000
        };

        return {
            displaySuccess: displaySuccess,
            displayError: displayError,
            displayWarning: displayWarning,
            displayInfo: displayInfo
        }
        //Thông báo thành công
        function displaySuccess(message) {
            toastr.success(message);
        }
        //Thông báo lỗi
        function displayError(error) {
            if (Array.isArray(error)){
                error.each(function(err){
                    toastr.error(err);
                });
            }
            else {
                toastr.error(error);
            }
        }
        //Thông báo cảnh báo
        function displayWarning(message) {
            toastr.warning(message);
        }
        //Thông báo thông tin
        function displayInfo(message) {
            toastr.info(message);
        }
    }
})(angular.module('phuotshop.common'));