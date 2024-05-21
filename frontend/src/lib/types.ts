import { PetType } from "./enum";

export interface Pet {
  id: string;
  name: string;
  createdOn: string;
  type: PetType;
  color: string;
  age: number;
}

export type CreatePet = Omit<Pet, "id" | "createdOn">;

export interface PetData {
  pets: Pet[];
  petsAgeSum: number;
}
