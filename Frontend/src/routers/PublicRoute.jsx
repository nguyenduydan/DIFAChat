import React from "react";
import { Navigate } from "react-router-dom";
import { ROUTES } from "./route.config";
import { Loading } from "@components/ui/Loading";

const PublicRoute = ({
  children,
  restricted = false, // Nếu true, user đã login sẽ không được truy cập
  redirectTo = ROUTES.HOME,
}) => {
  // Nếu route bị restricted và user đã login, redirect về dashboard
  if (restricted) {
    return <Navigate to={redirectTo} replace />;
  }

  return children;
};

export default PublicRoute;
