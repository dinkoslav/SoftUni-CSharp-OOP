<?php

class SingleRoom extends Room {
    const EXTRAS = "TV, air-conditioner";
    const BED_COUNT = 1;

    public function __construct($roomNumber, $price) {
        parent::__construct(RoomType::Standart, TRUE, FALSE, SingleRoom::BED_COUNT,
            $roomNumber, $extras = SingleRoom::EXTRAS, $price);
    }
}