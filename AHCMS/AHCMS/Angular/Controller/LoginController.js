var app = angular.module("app", ['ui.router', 'loader']);

app.controller("loginController", function ($scope, appService) {

    $scope.openModal = function (id) {
        debugger;
        var dlgElem = angular.element(id);
        if (dlgElem) {
            dlgElem.modal("show");
        }
    }

    $scope.ValidatePatient = function () {
        debugger; 
        var user = {
            Email: $scope.Email,
            Password: $scope.Password
        }

        var result = appService.ValidateUser(user, "/Account/PatientLogin");
        result.then(function (response) {         
            alert("welcome");
        }, function () {          
            alert('Error in Validating user');
        });
    }

    $scope.ForgotPassword_Patient = function () {
        debugger;

        var user = {
            Email: $scope.ForgotEmail,
            Username: $scope.ForgotUsername
        }
     
        var result = appService.ValidateUser(user, "/Account/ForgotPassword_Patient");
        result.then(function (response) {
            if (response.data == 0) {
                alert('Error in Validating user !');
            }
            else {
                appService.RedirectToURL('/Account/ForgotPassword');
            }
        }, function () {
            alert('Error in Validating user');
        });
    }

    $scope.ForgotPassword_Employee = function () {
        debugger;
        var user = {
            Email: $scope.Email,
            Username: $scope.Username
        }

        var result = appService.ValidateUser(user, "/Account/ForgotPassword_Employee");
        result.then(function (response) {
            if (response.data == 0) {
                alert('Error in Validating user !');
            }
            else {
                alert("Please check yor mail");
            }

        }, function () {
            alert('Error in Validating user');
        });
    }

    $scope.AddPatient = function () {
        debugger;
        var user = {
            Username: $scope.Username,
            Password: $scope.Password,
            Email: $scope.Email,
            CountryCode: $scope.CountryCode,
            PhoneNumber: $scope.PhoneNumber,
            FirstName: $scope.FirstName,
            MiddleName: $scope.MiddleName,
            LastName: $scope.LastName,
            BirthDate: $scope.BirthDate,
            Street: $scope.Street,
            City: $scope.City,
            State: $scope.State,
            Country: $scope.Country,
            Street: $scope.Street,
            BloodGroup: $scope.BloodGroup,
            Gender: $scope.Gender,
            ZipCode: $scope.ZipCode
        }

        var result = appService.ProcessData(user, "/Account/PatientRegister");
        result.then(function (response) {
            if (response.data == 0) {
                alert('Error in Adding record !');
            }
            else {
                alert('Sucessfully, Adding record');
            }
        }, function () {
            alert('Error in Adding record');
        });
    }

    $scope.AddEmployee = function () {
        debugger;
        var user = {
            Username: $scope.Username,
            Password: $scope.Password,
            Role: $scope.Role,
            Email: $scope.Email,
            CountryCode: $scope.CountryCode,
            PhoneNumber: $scope.PhoneNumber,
            FirstName: $scope.FirstName,
            MiddleName: $scope.MiddleName,
            LastName: $scope.LastName,
            BirthDate: $scope.BirthDate,
            Street: $scope.Street,
            City: $scope.City,
            State: $scope.State,
            Country: $scope.Country,
            Street: $scope.Street,
            BloodGroup: $scope.BloodGroup,
            Gender: $scope.Gender
        }
        var result = appService.ProcessData(user, "/Home/AddEmployee");
        result.then(function (response) {
            alert(response.data);
        }, function () {
            alert('Error in Adding record');
        });
    }

});

//app.controller('appController', ['$scope', '$rootScope',
//    function ($scope) {
//        $rootScope.$on('LOAD', function () { $scope.loading = true });
//        $rootScope.$on('UNLOAD', function () { $scope.loading = false });        
//    }
//]);
