<?php


class BookingManager {
    public static function bookRoom($room, $reservation){
        try{
            $room->addReservation($reservation);
            echo 'Room <strong>' . $room->getRoomNumber() .
                '</strong> successfully booked for ' . $reservation . "</br>";
        }
        catch (Exception $e){
            echo 'Room <strong>' . $room->getRoomNumber() . $e->getMessage() . "</strong></br>";
        }
    }
} 