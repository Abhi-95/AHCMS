var app = angular.module("app", ['angular-loading-bar']);
   
app.controller("loginController", function ($scope, AuthenticationService) {

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
            Email =$scope.Email,
            Password = $scope.Password
        }

        var result = AuthenticationService.ValidatePatient(user, "/Account/PatientLogin");
        result.then(function (response) {
            alert("welcome");
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
            Gender: $scope.Gender
        }
        var result = AuthenticationService.AddUser(user, "/Home/AddPatient");
        result.then(function (response) {
            alert(response.data);
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
        var result = AuthenticationService.AddUser(user, "/Home/AddEmployee");
        result.then(function (response) {
            alert(response.data);
        }, function () {
            alert('Error in Adding record');
        });
    }

});