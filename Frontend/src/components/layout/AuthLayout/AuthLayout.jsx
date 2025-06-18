// AuthLayout.jsx
import React from "react";
import { Outlet } from "react-router-dom";
import SplashCursor from "./components/SplashCursor";

const AuthLayout = () => {
  return (
    <div className="w-full min-h-screen flex items-center justify-center bg-black">
      <SplashCursor />
      <div className="w-full min-h-screen flex items-center justify-center z-2">
        <Outlet />
      </div>
    </div>
  );
};

export default AuthLayout;
