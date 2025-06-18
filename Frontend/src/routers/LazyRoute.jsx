import React, { Suspense } from "react";
import { ErrorBoundary } from "@components/common/ErrorBoundary";
import { Loading } from "@components/ui/Loading";

const LazyRoute = ({
  component: Component,
  fallback = <Loading />,
  errorFallback,
  ...props
}) => {
  if (!Component) {
    throw new Error(
      "LazyRoute: 'component' prop is required and must be a valid React component."
    );
  }
  return (
    <ErrorBoundary fallback={errorFallback}>
      <Suspense fallback={fallback}>
        {React.createElement(Component, props)}
      </Suspense>
    </ErrorBoundary>
  );
};

export default LazyRoute;
