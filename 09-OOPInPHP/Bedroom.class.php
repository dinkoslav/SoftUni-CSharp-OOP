<?php

class Bedroom extends Room {
    const EXTRAS = "TV, air-conditioner, refrigerator, mini-bar, bathtub";
    const BED_COUNT = 2;

    public function __construct($roomNumber, $price) {
        parent::__construct(RoomType::Gold, TRUE, TRUE, SingleRoom::BED_COUNT,
            $roomNumber, $extras = Bedroom::EXTRAS, $price);
    }
}