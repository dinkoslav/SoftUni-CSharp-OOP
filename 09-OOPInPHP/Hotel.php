<?php

function __autoload($className) {
    include_once("./" . $className . ".class.php");
}

date_default_timezone_set("Europe/Sofia");

$room = new SingleRoom(1408, 99);
$guest = new Guest("Svetlin", "Nakov", 8003224277);
$startDate = strtotime("24.10.2015");
$endDate = strtotime("26.10.2015");
$reservation = new Reservation($startDate, $endDate, $guest);

$room2 = new SingleRoom(1418, 100);
$guest2 = new Guest("Dinko", "Minkov", 8003224277);
$startDate2 = strtotime("24.10.2015");
$endDate2 = strtotime("26.10.2015");
$reservation2 = new Reservation($startDate2, $endDate2, $guest2);

$room3 = new Bedroom(1118, 250);
$guest3 = new Guest("Todor", "Batkov", 8003224277);
$startDate3 = strtotime("24.10.2015");
$endDate3 = strtotime("26.10.2015");
$reservation3 = new Reservation($startDate3, $endDate3, $guest3);

$room4 = new Bedroom(2418, 300);
$guest4 = new Guest("Byrzak", "Begachov", 8003224277);
$startDate4 = strtotime("24.10.2015");
$endDate4 = strtotime("26.10.2015");
$reservation4 = new Reservation($startDate4, $endDate4, $guest4);

$room5 = new Apartment(918, 150);
$guest5 = new Guest("Alpinist", "Katerachov", 8003224277);
$startDate5 = strtotime("24.10.2015");
$endDate5 = strtotime("26.10.2015");
$reservation5 = new Reservation($startDate5, $endDate5, $guest5);

$room6 = new Apartment(666, 200);
$guest6 = new Guest("Neznaiko", "Umnikov", 8003224277);
$startDate6 = strtotime("24.10.2015");
$endDate6 = strtotime("26.10.2015");
$reservation6 = new Reservation($startDate6, $endDate6, $guest6);


$rooms = [$room, $room2, $room3, $room4, $room5, $room6];

BookingManager::bookRoom($room, $reservation);
BookingManager::bookRoom($room, $reservation);

// Filter the array by bedrooms and apartments with a price less or equal to 250.00
$filteredRooms = array_filter($rooms, function ($room){
    if(get_class($room) == "Bedroom" || get_class($room) == "Apartment"){
        return $room->getPrice() <= 250;
    }
});

//foreach ($filteredRooms as $froom) {
//    echo $froom . "price: " . $froom->getPrice() . "</br>";
//}

// Filter the array by all rooms with a balcony
$filteredRoomsBalcony = array_filter($rooms, function ($room){
        return $room->getHasBalcony() == "has balcony";
});

//foreach ($filteredRoomsBalcony as $froom) {
//    echo $froom . "</br>";
//}

// Return the room numbers of all rooms which have a bathtub in their extras
$filteredRoomsBathtub = array_filter($rooms, function ($room){
    return strpos($room->getExtras(),'bathtub') !== false;
});

//foreach ($filteredRoomsBathtub as $froom) {
//    echo $froom->getRoomNumber() . "</br>";
//}
?>