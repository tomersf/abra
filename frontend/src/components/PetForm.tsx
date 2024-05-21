"use client";
import { createPet } from "@/lib/api";
import { PetType } from "@/lib/enum";
import { useRouter } from "next/navigation";
import React, { useState } from "react";
import { CircleLoader } from "react-spinners";
import { toast } from "sonner";

const PetForm = () => {
  const router = useRouter();
  const [submitted, setSubmitted] = useState(false);
  const [name, setName] = useState("");
  const [color, setColor] = useState("#050505");
  const [age, setAge] = useState(0);
  const [type, setType] = useState<PetType>(PetType.Dog);
  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    setSubmitted(true);
    e.preventDefault();
    const pet = await createPet({ name, color, age, type });
    if (pet instanceof Error) {
      toast("Something went wrong...");
    }
    setSubmitted(false);
    if (!(pet instanceof Error)) {
      router.push("/");
    }
  };

  return submitted ? (
    <CircleLoader />
  ) : (
    <form
      onSubmit={handleSubmit}
      className="flex flex-col gap-3 shadow-lg p-3 w-1/3"
    >
      <div className="flex gap-2">
        <label htmlFor="name">Name:</label>
        <input
          type="text"
          id="name"
          value={name}
          onChange={(e) => setName(e.target.value)}
          disabled={submitted}
        />
      </div>
      <div className="flex gap-2">
        <label htmlFor="color">Color (Hex):</label>
        <input
          type="color"
          id="color"
          value={color}
          onChange={(e) => setColor(e.target.value)}
          disabled={submitted}
        />
      </div>
      <div className="flex gap-2">
        <label htmlFor="age">Age:</label>
        <input
          type="number"
          id="age"
          max={20}
          min={0}
          value={age}
          onChange={(e) => setAge(Number(e.target.value))}
          disabled={submitted}
        />
      </div>
      <div className="flex gap-2">
        <label htmlFor="type">Type:</label>
        <select
          disabled={submitted}
          id="type"
          value={type}
          onChange={(e) => setType(e.target.value as PetType)}
        >
          {Object.values(PetType).map((petType) => (
            <option key={petType} value={petType}>
              {petType}
            </option>
          ))}
        </select>
      </div>
      <button type="submit" disabled={submitted}>
        Submit
      </button>
    </form>
  );
};

export default PetForm;
