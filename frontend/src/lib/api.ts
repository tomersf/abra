import axios from "axios";
import { CreatePet, Pet, PetData } from "./types";

const BACKEND_API = "http://localhost:5002/api/pet";

export async function fetchPets() {
  try {
    const pets = await axios.get<PetData>(BACKEND_API);

    return pets.data;
  } catch (error) {
    return new Error("Error on fetching pets");
  }
}

export async function createPet(pet: CreatePet) {
  try {
    const createPet = await axios.post<Pet>(BACKEND_API, JSON.stringify(pet), {
      headers: {
        "Content-Type": "application/json",
      },
    });
    return createPet.data;
  } catch (error) {
    return new Error("Error on creating a pet");
  }
}
