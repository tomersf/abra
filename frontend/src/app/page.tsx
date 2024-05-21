import MyPets from "@/components/MyPets";

export default function Home() {
  return (
    <main className="flex flex-col items-center justify-between p-12">
      <h1 className="text-3xl font-bold italic">Welcome to Abra Pet!</h1>
      <div className="mt-12">
        <MyPets />
      </div>
    </main>
  );
}
