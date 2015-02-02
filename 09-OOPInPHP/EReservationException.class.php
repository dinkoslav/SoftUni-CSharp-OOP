<?php


class EReservationException extends Exception{

    function __construct()
    {
        parent::__construct(" is occupied for this period", 101);
    }
}