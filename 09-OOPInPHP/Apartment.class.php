<?php

class Apartment extends Room {
    const EXTRAS = "TV, air-conditioner, refrigerator, kitchen box, mini-bar, bathtub, free Wi-fi";
    const BED_COUNT = 4;

    public function __construct($roomNumber, $price) {
        parent::__construct(RoomType::Diamond, TRUE, TRUE, SingleRoom::BED_COUNT,
            $roomNumber, $extras = Apartment::EXTRAS, $price);
    }
}