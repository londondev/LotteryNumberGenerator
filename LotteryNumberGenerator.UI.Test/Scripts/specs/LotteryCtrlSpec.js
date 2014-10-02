'use strict';

describe('Testing Controller: lotteryCtrl', function () {

    beforeEach(module('lotteryApp'));

    var scope, mockedDataServiceFactory, controller, q, deferred;

    //Prepare the fake factory
    beforeEach(function () {
        mockedDataServiceFactory = {
            saveNumbers: function () {
                deferred = q.defer();
                // Place the fake return object here
                deferred.resolve(1);
                return deferred.promise;
            },
            numbers: function () {
                deferred = q.defer();
                // Place the fake return object here
                deferred.resolve(1);
                return deferred.promise;
            },
        };
        spyOn(mockedDataServiceFactory, 'saveNumbers').and.callThrough();
        spyOn(mockedDataServiceFactory, 'numbers').and.callThrough();
    });

    //Inject fake factory into controller
    beforeEach(inject(function ($rootScope, $controller, $q) {
        scope = $rootScope.$new();
        q = $q;
        controller = $controller('lotteryCtrl', { $scope: scope, dataServiceFac: mockedDataServiceFactory });
    }));

        it('calling save should increase counter on success', function () {
            scope.saveNumber();
            scope.$digest();
            expect(scope.numberInDraw).toBe(1);
        });

        it('calling generate new number should set scope.numbers', function () {
            scope.generateNumber();
            scope.$digest();
            expect(scope.numbers).toBe(1);
        });

        it('calling generateNumber should change the style of the boxes to red', function () {
            scope.generateNumber();
            scope.$digest();
            expect(scope.class).toBe('redBox');
        });

        it('calling saveNumber should change the style of the boxes to grey', function () {
            scope.saveNumber();
            scope.$digest();
            expect(scope.class).toBe('greyBox');
        });
})
