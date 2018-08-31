var app = angular.module("app", ['ui.router']);

app.config(function ($stateProvider, $urlRouterProvider) {

  $urlRouterProvider.otherwise('/home');

  $stateProvider  
      .state('home', {
        url: '/home',
        templateUrl: '/Account/PatientLogin'
      }) 
      .state('register', {
        url: '/register',
        templateUrl: '/Account/PatientSignUp'
      })
    .state('Forgot', {
      url: '/Forgot',
      templateUrl: '/Account/ForgotPassword.html'
    })
});