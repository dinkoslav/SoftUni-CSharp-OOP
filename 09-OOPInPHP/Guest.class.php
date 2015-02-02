<?php


class Guest {
    private $firstName;
    private $lastName;
    private $iD;

    function __construct($firstName, $lastName, $iD)
    {
        $this->setFirstName($firstName);
        $this->setID($iD);
        $this->setLastName($lastName);
    }

    public function getFirstName()
    {
        return $this->firstName;
    }

    public function setFirstName($firstName)
    {
        if(empty($firstName) || !isset($firstName)){
            trigger_error("Invalid First Name");
        }
        $this->firstName = $firstName;
    }

    public function getID()
    {
        return $this->iD;
    }

    public function setID($iD)
    {
        if(strlen($iD) != 10 || !is_numeric($iD)){
            trigger_error("Invalid ID");
        }
        $this->iD = $iD;
    }

    public function getLastName()
    {
        return $this->lastName;
    }

    public function setLastName($lastName)
    {
        if(empty($lastName) || !isset($lastName)){
            trigger_error("Invalid Last Name");
        }
        $this->lastName = $lastName;
    }

    public function __toString()
    {
        return "<strong>" . $this->getFirstName() . " " . $this->getLastName() . "</strong>";
    }


} 