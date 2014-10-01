'use strict'

lotteryApp.controller('lotteryCtrl', ['$scope','dataServiceFac', function ($scope,dataServiceFac) {
    
    $scope.numberInDraw = 0;
    $scope.generateNumber = function () {
        dataServiceFac.numbers().then(function (data) {
            $scope.numbers = data;
            $scope.class = "redBox";
        });
    };

   
    $scope.saveNumber = function () {
        dataServiceFac.saveNumbers($scope.numbers).then(function (data) {
            console.log("number is saved");
            reset();
            $scope.numberInDraw = data;
        })
    }


    $scope.reset = function () {
        reset();
    };

    function reset(){
        $scope.class = "greyBox";
        $scope.numbers = ["","","","","",""];
    }
    reset();
    
}])