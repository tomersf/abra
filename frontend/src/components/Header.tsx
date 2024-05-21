import Link from "next/link";
import React from "react";
import { Button } from "./ui/button";

type Props = {};

const Header = (props: Props) => {
  return (
    <nav className="flex w-full p-2  bg-primary-foreground">
      <div className="w-full">
        <ul className="flex gap-3 px-1 items-center justify-between w-[95%]">
          <li>
            <Link href="/">
              <h1 className="text-4xl">Abra Pet</h1>
            </Link>
          </li>
          <li>
            <Link href="/pet">
              <Button>Create a Pet</Button>
            </Link>
          </li>
        </ul>
      </div>
    </nav>
  );
};

export default Header;
