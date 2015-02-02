<?php


class Reservation {
    private $startDate;
    private $endDate;
    private $guest;

    function __construct($startDate, $endDate, Guest $guest)
    {
        $this->setEndDate($endDate);
        $this->setGuest($guest);
        $this->setStartDate($startDate);
    }



    public function getStartDate()
    {
        return $this->startDate;
    }

    public function setStartDate($startDate)
    {
        if($startDate < strtotime("now")){
            trigger_error("Invalid Start Reservation Date");
        }
        $this->startDate = $startDate;
    }

    public function getEndDate()
    {
        return $this->endDate;
    }

    public function setEndDate($endDate)
    {
        if(strtotime($endDate) < $this->getStartDate()){
            trigger_error("Invalid End Reservation Date");
        }
        $this->endDate = $endDate;
    }

    public function getGuest()
    {
        return $this->guest;
    }

    public function setGuest($guest)
    {
        $this->guest = $guest;
    }

    public function __toString()
    {
        return $this->getGuest() . ' from <time>' . date("d.m.Y", $this->getStartDate()) . '</time> to <time>' .
        date("d.m.Y", $this->getEndDate()) . '</time>!';
    }
}