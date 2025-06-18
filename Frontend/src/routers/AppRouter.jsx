import React, { lazy } from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import { ROUTES } from "./route.config";
import LazyRoute from "./LazyRoute";
import PublicRoute from "./PublicRoute";

// Import layout
import AuthLayout from "@components/layout/AuthLayout/AuthLayout";

// Lazy load components
const Home = lazy(() => import("@pages/Home"));
const Login = lazy(() => import("@pages/Auth/Login"));

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
        <Route path="/auth" element={<AuthLayout />}>
          <Route
            path="login"
            element={
              <PublicRoute restricted={false}>
                <LazyRoute component={Login} />
              </PublicRoute>
            }
          />
        </Route>
        <Route path="*" element={<Navigate to={ROUTES.HOME} />} />
      </Routes>
    </>
  );
};

export default AppRouter;
