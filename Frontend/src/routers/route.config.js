// Route definitions
export const ROUTES = {
  // Public client-side routes
  HOME: "/",
  BLOG: "/blogs",

  // Authentication routes
  LOGIN: "/auth/login",
  REGISTER: "/auth/register",
  FORGOT_PASSWORD: "/auth/forgot-password",
  RESET_PASSWORD: "/auth/reset-password",
  VERIFY_EMAIL: "/auth/verify-email",

  // Authenticated user routes
  PROFILE: "/profile",
  SETTINGS: "/settings",

  // Admin panel routes
  ADMIN: "/admin",
  ADMIN_USERS: "/admin/users",
  ADMIN_DASHBOARD: "/admin/dashboard",

  // Error pages
  NOT_FOUND: "/404",
  SERVER_ERROR: "/500",
  UNAUTHORIZED: "/401",
  FORBIDDEN: "/403",
};

// Permissions per route
export const ROUTE_PERMISSIONS = {
  [ROUTES.ADMIN]: ["admin"],
  [ROUTES.ADMIN_USERS]: ["admin", "super_admin"],
  [ROUTES.ADMIN_DASHBOARD]: ["admin", "super_admin"],
  [ROUTES.PROFILE]: ["user"],
  [ROUTES.SETTINGS]: ["user"],
};

// Routes accessible without authentication
export const PUBLIC_ROUTES = [
  ROUTES.HOME,
  ROUTES.BLOG,
  ROUTES.LOGIN,
  ROUTES.REGISTER,
  ROUTES.FORGOT_PASSWORD,
  ROUTES.RESET_PASSWORD,
  ROUTES.VERIFY_EMAIL,
  ROUTES.NOT_FOUND,
  ROUTES.SERVER_ERROR,
  ROUTES.UNAUTHORIZED,
  ROUTES.FORBIDDEN,
];

// Authentication-only routes
export const AUTH_ROUTES = [
  ROUTES.LOGIN,
  ROUTES.REGISTER,
  ROUTES.FORGOT_PASSWORD,
  ROUTES.RESET_PASSWORD,
  ROUTES.VERIFY_EMAIL,
];
