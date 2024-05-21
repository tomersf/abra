"use client";
import { fetchPets } from "@/lib/api";
import { PetData } from "@/lib/types";
import React, { useEffect, useState } from "react";
import CircleLoader from "react-spinners/CircleLoader";
import PetCard from "./PetCard";
import { toast } from "sonner";

type Props = {};

const MyPets = (props: Props) => {
  const [petsData, setPetsData] = useState<PetData>();
  const [isFetchingPets, setIsFetchingPets] = useState(false);

  useEffect(() => {
    const getPetsData = async () => {
      setIsFetchingPets(true);
      const petsData = await fetchPets();
      if (petsData instanceof Error) {
        toast("Unable to get pets.. try again!");
        return;
      }
      setPetsData(petsData);
      setIsFetchingPets(false);
    };
    getPetsData();
  }, []);

  return (
    <div>
      {isFetchingPets ? (
        <CircleLoader />
      ) : (
        <div>
          <h3>Ages Sum: {petsData?.petsAgeSum}</h3>
          <h4>Total pets: {petsData?.pets.length}</h4>
          <div className="grid grid-cols-3 gap-4">
            {petsData?.pets.map((pet) => (
              <div key={pet.id}>
                <PetCard pet={pet} />
              </div>
            ))}
          </div>
        </div>
      )}
    </div>
  );
};

export default MyPets;
