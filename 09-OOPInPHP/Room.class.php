<?php


class Room implements iReservable{
    private $roomType;
    private $hasRestRoom;
    private $hasBalcony;
    private $bedCount;
    private $roomNumber;
    private $extras;
    private $price;
    private $reservations = [];

    function __construct($roomType, $hasRestRoom, $hasBalcony,
                         $bedCount, $roomNumber, $extras, $price)
    {
        $this->setBedCount($bedCount);
        $this->setExtras($extras);
        $this->setHasBalcony($hasBalcony);
        $this->setHasRestRoom($hasRestRoom);
        $this->setPrice($price);
        $this->setRoomNumber($roomNumber);
        $this->setRoomType($roomType);
    }

    public function getBedCount()
    {
        return $this->bedCount;
    }

    public function setBedCount($bedCount)
    {
        $this->bedCount = $bedCount;
    }

    public function getExtras()
    {
        return $this->extras;
    }

    public function setExtras($extras)
    {
        $this->extras = $extras;
    }

    public function getHasBalcony()
    {
        if($this->hasBalcony == TRUE){
            return "has balcony";
        } else {
            return "no balcony";
        }
    }

    public function setHasBalcony($hasBalcony)
    {
        $this->hasBalcony = $hasBalcony;
    }

    public function getHasRestRoom()
    {
        if($this->hasRestRoom == TRUE){
            return "has restroom";
        } else {
            return "no restroom";
        }
    }

    public function setHasRestRoom($hasRestRoom)
    {
        $this->hasRestRoom = $hasRestRoom;
    }

    public function getPrice()
    {
        return $this->price;
    }

    public function setPrice($price)
    {
        if($price <=0 || !is_numeric($price)){
            trigger_error("Invalid Price");
        }
        $this->price = $price;
    }

    public function getRoomNumber()
    {
        return $this->roomNumber;
    }

    public function setRoomNumber($roomNumber)
    {
        if($roomNumber <=0 || !is_numeric($roomNumber)){
            trigger_error("Invalid Room Number");
        }
        $this->roomNumber = $roomNumber;
    }

    public function getRoomType()
    {
        switch($this->roomType){
            case 1: return "Standart"; break;
            case 2: return "Gold"; break;
            case 3: return "Diamond"; break;
        }
    }

    public function setRoomType($roomType)
    {
        $this->roomType = $roomType;
    }

    public function addReservation(Reservation $reservation)
    {
        $startDate = $reservation->getStartDate();
        $endDate = $reservation->getEndDate();

        foreach ($this->reservations as $takenReservations){
            if(($startDate >= $takenReservations->getStartDate() &&
                    $startDate <= $takenReservations->getEndDate() &&
                    $endDate >= $takenReservations->getStartDate()  &&
                    $endDate <= $takenReservations->getEndDate()) ||
                    ($startDate <= $takenReservations->getStartDate() &&
                    $endDate >= $takenReservations->getEndDate())){
                throw new EReservationException();
            }
        }
        $this->reservations[] = $reservation;

    }


    function removeReservation(Reservation $reservation)
    {
        foreach ($this->reservations as $key => $takenReservations) {
            if($takenReservations === $reservation){
                unset($this->reservations[$key]);
            }
        }
    }

    public function __toString() {
        $roominfo = "Room " . $this->getRoomNumber() . ", room type " .
        $this->getRoomType() . ", " . $this->getHasRestRoom() .
        ", " . $this->getHasBalcony() . ", " . $this->getBedCount() .
        " bed(s), " . "extras - " . $this->getExtras() . "</br>Reservations: </br>";

        foreach ($this->reservations as $reservation) {
            $roominfo .= $reservation . "</br>";
        }
        return $roominfo;
    }
} 