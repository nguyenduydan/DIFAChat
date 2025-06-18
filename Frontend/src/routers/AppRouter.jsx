import React, { lazy } from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import { ROUTES } from "./route.config";
import LazyRoute from "./LazyRoute";
import PublicRoute from "./PublicRoute";

// Lazy load components
const Home = lazy(() => import("@pages/Home"));
const AppRouter = () => {
  return (
    <>
      <Routes>
        <Route
          path={ROUTES.HOME}
          element={
            <PublicRoute>
              <LazyRoute component={Home} />
            </PublicRoute>
          }
        />
        <Route path="*" element={<Navigate to={ROUTES.HOME} />} />
      </Routes>
    </>
  );
};

export default AppRouter;
