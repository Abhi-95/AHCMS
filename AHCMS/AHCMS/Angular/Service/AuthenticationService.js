app.service("AuthenticationService", function ($http) {
    // Validating patient
    this.ValidatePatient = function (user,url) {
        var response = $http({
            method: "post",
            url: url,
            data: JSON.stringify(user),
            dataType: "json"
        });
        return response;
    };

    //Add new Patient
    this.AddUser = function (user,url) {
        var response = $http({
            method: "post",
            url: url,
            data: JSON.stringify(user),
            dataType: "json"
        });
        return response;
    }
    //
    //get All Books
    this.getBooks = function () {
        return $http.get("/Home/GetBook");
    };

    // get Book by bookId
    this.getBook = function (bookId) {
        debugger
        var response = $http({
            method: "post",
            url: "/Home/GetBookByID",
            params: {
                id: JSON.stringify(bookId)
            }
        });
        return response;
    }

    //Delete Book
    this.DeleteBook = function (bookId) {
        debugger
        var response = $http({
            method: "post",
            url: "/Home/DeleteBook",
            params: {
                id: JSON.stringify(bookId)
            }
        });
        return response;
    }

    //Add Book
    this.AddBook = function (book) {
        var response = $http({
            method: "post",
            url: "/Home/AddBook",
            data: JSON.stringify(book),
            dataType: "json"
        });
        return response;
    }

    //Update Book
    this.editBook = function (book) {
        var response = $http({
            method: "post",
            url: "/Home/UpdateBook",
            data: JSON.stringify(book),
            dataType: "json"
        });
        return response;
    }
});