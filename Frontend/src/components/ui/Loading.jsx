import React from "react";

export const Loading = () => {
  return (
    <div className="flex h-screen items-center justify-center bg-gradient-to-br from-blue-100 to-white">
      <div className="flex flex-col items-center space-y-4">
        <div className="relative">
          <div className="h-16 w-16 animate-spin rounded-full border-4 border-blue-500 border-t-transparent" />
        </div>
        <h1 className="text-lg font-bold text-blue-700 tracking-wide">
          DIFA Chat
        </h1>
      </div>
    </div>
  );
};
