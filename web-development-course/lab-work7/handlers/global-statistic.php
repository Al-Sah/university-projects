<?php

    header("Content-type: text/xml; charset=utf-8");
    require_once '../vendor/autoload.php';
    require_once '../ui-components.php';
    use lib\db\GlobalStatisticDAO;

    function toXML(SimpleXMLElement $object, array $data): void{
        foreach ($data as $key => $value) {
            if (is_array($value)) {
                $new_object = $object->addChild($key);
                toXML($new_object, $value);
            } else {
                // if the key is an integer, it needs text with it to actually work.
                if ($key != 0 && $key == (int) $key) {
                    $key = "key_$key";
                }
                $object->addChild($key, $value);
            }
        }
    }

    try {
        $globalStatistic = (array) GlobalStatisticDAO::get();
    } catch (Exception $e) {
        exit;
    }

    $xml = new SimpleXMLElement('<response/>');
    toXML($xml, $globalStatistic);
    print $xml->asXML();
