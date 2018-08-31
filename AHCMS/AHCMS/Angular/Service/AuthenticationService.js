app.service("appService", function ($http, $window) {
    // Validating patient
    this.ValidateUser = function (user, url) {
        debugger
        var response = $http({
            method: "post",
            url: url,
            data: JSON.stringify(user),
            dataType: "json"
        });
        return response;
    };

    //Add or Edit Data
    this.ProcessData = function (user,url) {
        var response = $http({
            method: "post",
            url: url,
            data: JSON.stringify(user),
            dataType: "json"
        });
        return response;
    }
    
    //get All Data
    this.getData = function (url) {
        return $http.get(url);
    };

    // get or delete Data by Id
    this.getOrDeleteData = function (Id, url) {
        debugger
        var response = $http({
            method: "post",
            url: url,
            params: {
                id: JSON.stringify(Id)
            }
        });
        return response;
    };

    this.RedirectToURL = function (url) {
        var host = $window.location.host;
        var landingUrl = "http://" + host + url;

        $window.location.href = landingUrl; //Redirect to given URLs.
    };


});