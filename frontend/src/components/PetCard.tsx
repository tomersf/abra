import { Pet } from "@/lib/types";
import React from "react";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";

type Props = {
  pet: Pet;
};

const PetCard = ({ pet }: Props) => {
  const petCreatedOnDate = new Date(pet.createdOn);
  const formattedDate = new Intl.DateTimeFormat("en-GB", {
    day: "2-digit",
    month: "2-digit",
    year: "numeric",
  }).format(petCreatedOnDate);

  return (
    <Card>
      <CardHeader>
        <CardTitle>{pet.name}</CardTitle>
        <CardDescription>Pet Type: {pet.type}</CardDescription>
      </CardHeader>
      <CardContent className="flex flex-col">
        <span>Color: {pet.color}</span>
        <span>Age: {pet.age}</span>
        <span>Created on: {formattedDate}</span>
      </CardContent>
      <CardFooter>
        <p className="font-light">Id: {pet.id}</p>
      </CardFooter>
    </Card>
  );
};

export default PetCard;
