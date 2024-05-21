import PetForm from "@/components/PetForm";
import React from "react";

type Props = {};

const Page = (props: Props) => {
  return (
    <div className="flex flex-col items-center justify-between pt-12 gap-8">
      <div className="text-3xl font-semibold">Pet Creation</div>
      <PetForm />
    </div>
  );
};

export default Page;
