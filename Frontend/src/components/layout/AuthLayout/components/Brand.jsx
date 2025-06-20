import React from "react";
import Logo from "@assets/Logo/icon.png"; // Adjust the path as necessary
const Brand = () => {
  return (
    <div className="flex items-center space-x-2">
      <img src={Logo} alt="DifaChat Logo" className="w-8 h-8 sm:w-10 sm:h-10" />
      <h1 className="text-xl sm:text-2xl md:text-3xl text-transparent *:font-bold bg-gradient-to-r from-white via-gray-100 to-gray-300 bg-clip-text">
        <span className="uppercase text-transparent bg-gradient-to-r from-indigo-500 to-violet-300 bg-clip-text">
          Difa
        </span>{" "}
        Chat
      </h1>
    </div>
  );
};

export default Brand;
