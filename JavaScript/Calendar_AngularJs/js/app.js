angular.module('myCalendar', [])
.controller('setDay', function($scope){
	
$scope.months = [ "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" ];
$scope.lables = ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"];

$scope.date = new Date();

var positionMonth =  $scope.date.getMonth();
$scope.monthNow = $scope.months[positionMonth];
$scope.year = $scope.date.getFullYear();
$scope.selectDay = $scope.date.getDate();
function UpdateDate(){
	$scope.date = new Date($scope.year, positionMonth, $scope.selectDay);
}


// переключение года вперед
	$scope.nextYear = function() {
		$scope.date.setFullYear($scope.date.getFullYear() + 1);
	}
// переключение года назад
	$scope.backYear = function() {
		$scope.date.setFullYear($scope.date.getFullYear() - 1);
	}

// переключает месяц в перед
	$scope.nextMonth = function() {
		positionMonth++;
		if(positionMonth < $scope.months.length){
			$scope.date.setMonth(positionMonth);
			$scope.monthNow = $scope.months[positionMonth];
			
		} else{
			positionMonth = 0;
			$scope.nextYear();
			$scope.date.setMonth(positionMonth);
			$scope.monthNow = $scope.months[positionMonth];
		}	
	}

// переключает месяц назад
	$scope.backMonth = function() {
		positionMonth--;
		if(positionMonth >= 0){
			$scope.monthNow = $scope.months[positionMonth];
			$scope.date.setMonth(positionMonth);
		} else {
			$scope.backYear();
			$scope.date.setMonth(positionMonth);
			positionMonth = $scope.months.length - 1;
			$scope.monthNow = $scope.months[positionMonth];
		}
	}

// функция для обновления дней


$scope.nextDay = function(){
	var day = $scope.selectDay;
	day++;
	if(day > new Date($scope.year,positionMonth, 0).getDate()){
		$scope.nextMonth();
		$scope.selectDay = 1;
		$scope.date.setDate($scope.selectDay);
		
	} else{
		$scope.selectDay++;
		$scope.date.setDate($scope.selectDay);
	}
}
$scope.backDay = function() {
	var day = $scope.selectDay;
	day--;
	if(day < 1){
		$scope.backMonth();
		$scope.selectDay = new Date($scope.year,positionMonth, 0).getDate();
		$scope.date.setDate($scope.selectDay);
	} else {
		$scope.selectDay--;
		$scope.date.setDate($scope.selectDay);
	}
}

function update(){
	var currentDay, lastDay, dayWeek;
	// ели месяц начинается не с понедельника то заполняем пропуски предыдущим месяцем
	if(dayweek != 0){
		for(var i = 0, j = dayweek; i < 8; i++, j--){
			$scope.dayarray[i] = lastday - j;
		}
		for(var i = dayweek, j = 1; i < 8; i++, j++){
			$scope.dayarray[i] = j;
		}
	} else {
		for(var i = 0; i < nowday; i++){
			$scope.dayarray[i] = i + 1;
		}
		for(var i = nowday, j = 1; i < 42; i++, j++){
			$scope.dayarray[i] = j;
		}
	}
}

})