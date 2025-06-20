import React from "react";
import { useLocation, Link } from "react-router-dom";
import Brand from "./Brand";

const Header = () => {
  const location = useLocation();

  const isLogin =
    location.pathname === "/auth/signin" || location.pathname === "/auth/login";
  const isRegister =
    location.pathname === "/auth/register" ||
    location.pathname === "/auth/signup";

  return (
    <header className="w-full py-3 sm:py-4 px-4 sm:px-6 md:px-8 lg:px-12">
      <div className="max-w-7xl mx-auto">
        <div className="flex items-center justify-between">
          {/* Logo - Left */}
          <Link to="/">
            <Brand />
          </Link>
          {/* Menu - Right */}
          <nav className="flex items-center space-x-2 sm:space-x-4">
            <div className="backdrop-blur-md bg-white/10 border border-white/20 rounded-full px-3 sm:px-4 py-1.5 sm:py-2 flex items-center space-x-2 sm:space-x-3">
              <Link
                to="/auth/login"
                className={`text-sm sm:text-base transition-all duration-200 px-2 sm:px-3 py-1 rounded-full active:scale-95
                  ${
                    isLogin
                      ? "text-white bg-gradient-to-r from-blue-600 to-purple-700"
                      : "text-gray-100 hover:bg-gray-600/30"
                  }`}
              >
                Sign In
              </Link>
              <div className="w-px h-4 bg-gray-500"></div>
              <Link
                to="/auth/register"
                className={`text-sm sm:text-base transition-all duration-200 px-3 sm:px-4 py-1 rounded-full active:scale-95
                  ${
                    isRegister
                      ? "text-white bg-gradient-to-r from-blue-600 to-purple-700"
                      : "text-gray-100 hover:bg-gray-600/30 "
                  }`}
              >
                Sign Up
              </Link>
            </div>
          </nav>
        </div>
      </div>
    </header>
  );
};

export default Header;
