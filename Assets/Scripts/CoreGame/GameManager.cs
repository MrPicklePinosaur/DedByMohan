﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static EventSystem;
public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

    Generator[] generators;
    Prison[] prisons;
    Spawnpoint[] spawnpoints;

    [SerializeField]int generatorsFinished = 0;

    void Start() {
        gameManager = this;

        generators = FindObjectsOfType<Generator>();
        prisons = FindObjectsOfType<Prison>();
        spawnpoints = FindObjectsOfType<Spawnpoint>();
    }


    public Prison FindOpenPrison() {
        foreach(Prison p in prisons) {
            if (p.occupiedBy == -1) {
                return p;
            }
        }
        return null;
    }

    public Generator FindGeneratorById(int id) {
        foreach(Generator g in generators) {
            if (g.interactable_id == id) {
                return g;
            }
        }
        return null;
    }

    public void FinishedGenerator() {
        generatorsFinished += 1;

        if (generatorsFinished >= 4) {
            //trigger win state

            Debug.Log("WIN YAYYYYYYYYY");
            eventSystem.RaiseNetworkEvent(EventCodes.OnSoundEvent, new object[] { "Sounds/win" });
        }
    }

    public Prison FindPrisonByOccupant(int actorId) {
        foreach(Prison p in prisons) {
            if (p.occupiedBy == actorId) {
                return p;
            }
        }
        return null;
    }

    public Spawnpoint FindSpawnpointById(int id) {
        foreach (Spawnpoint s in spawnpoints) {
            if (s.spawnpoint_id == id) {
                return s;
            }
        }
        return null;
    }

    
}
