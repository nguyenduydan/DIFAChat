// AuthLayout.jsx
import React from "react";
import { Outlet } from "react-router-dom";
import SplashCursor from "./components/SplashCursor";
import Header from "./components/Header";
import Footer from "./components/Footer";

const AuthLayout = () => {
  return (
    <div className="min-h-screen bg-gradient-to-br from-gray-900 via-black to-gray-900 flex flex-col overflow-x-hidden">
      {/* Background Pattern */}
      <div className="absolute inset-0 bg-[radial-gradient(circle_at_50%_50%,rgba(255,255,255,0.03),transparent)] pointer-events-none" />

      {/* Mobile-specific background dots */}
      <div className="absolute inset-0 sm:hidden bg-[radial-gradient(circle_at_25%_25%,rgba(255,255,255,0.02),transparent)] pointer-events-none" />
      <div className="absolute inset-0 sm:hidden bg-[radial-gradient(circle_at_75%_75%,rgba(255,255,255,0.02),transparent)] pointer-events-none" />

      {/* Optional Cursor Effect */}
      <SplashCursor />

      {/* Header */}
      <Header />

      {/* Main Content Area */}
      <main className="flex-1 flex items-center justify-center sm:px-2 md:px-8 lg:px-12 relative z-10">
        {/* Content wrapper with responsive padding */}
        <Outlet />
      </main>

      {/* Footer */}
      <Footer />
    </div>
  );
};

export default AuthLayout;
