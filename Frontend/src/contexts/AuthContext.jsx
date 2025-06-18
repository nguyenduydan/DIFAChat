import React, { createContext, useContext, useState, useEffect } from "react";

// Dummy auth, replace with real logic (e.g. Firebase, Supabase)
const fakeUser = {
  id: "1",
  email: "user@example.com",
  emailVerified: true,
  roles: ["admin"],
  permissions: ["read:users"],
};

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);

  useEffect(() => {
    // Simulate async login check
    const timeout = setTimeout(() => {
      setUser(fakeUser);
    }, 500);
    return () => clearTimeout(timeout);
  }, []);

  const isAuthenticated = !!user;

  return (
    <AuthContext.Provider value={{ user, isAuthenticated }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => useContext(AuthContext);
