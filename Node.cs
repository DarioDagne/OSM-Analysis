﻿using System;

// Klasse zur abstrakten Darstellung von geographischen Koordinaten
public class node
{

// Felder:

private static uint _nodeCounter = 1;            // Zählt Knoten

// Eigenschaften:

public string description { get; set; }         // Beschreibung des Punktes via String
public double lat { get; set; }                // Breitengrad des Punktes
public double lon { get; set; }                // Längengrad des Punktes

// Konstruktoren:

public node(string Description, double Latitude, double Longitude)
{
    description =   Description;
    lat         =   Latitude;
    lon         =   Longitude;
}

public node(double Latitude, double Longitude)
{
    description =   "P" + Convert.ToString(_nodeCounter);
    lat         =   Latitude;
    lon         =   Longitude;

    _nodeCounter += 1;
}
}

public class Entfernungsberechnung{

// Felder

node _node1;
node _node2;

// Konstruktoren

public Entfernungsberechnung(node Node1, node Node2){

_node1 = Node1;
_node2 = Node2;

}

// Methode zur Berechnung (kürzensten) Entfernung zweier Knoten
public void distance(uint method)
{

    // Variablen:

    double dx, dy;                          // Abstände P1 <--> P2 in km in kartesischen Koordinaten 
    double d_lat, d_lon;                    // Abstand zweier Breiten- bzw. Längengrade

    double lat1 = _node1.lat;
    double lon1 = _node1.lon;
    double lat2 = _node2.lat;
    double lon2 = _node2.lon;

    /* 
    Auswahl der Berechnungsmethode:
            1 - einfache Berechnung mittels Pythagoras
            2 - erweiterte Berechnung (planare Trigonometrie mit variablem Abstand der Längengrade)
            3 - Berechnung mittels Kugelkoordinaten
    */

    
    switch (method)
    {
        case 1: 
            // Methode mittels planarer Trigonometrie (Satz des Pythagoras)
            d_lat = 111;                    // fester Wert (konstant da "perfekte" Kugel)
            d_lon = 71.5;                   // fester Wert (angepasst auf deutsche Längengrade)

            dx = d_lon * (lon2-lon1);
            dy = d_lat * (lat2-lat1);
            Console.WriteLine($"Entfernung zwischen {_node1.description} und {_node2.description}: {Math.Sqrt(dx*dx+dy*dy)} km");
            break;
        case 2:
            
            break;
        case 3:
            
            break;
        default: 
            throw new ArgumentException("Invalid method! Choose either 1, 2 or 3!");
            
    }    
}
}


