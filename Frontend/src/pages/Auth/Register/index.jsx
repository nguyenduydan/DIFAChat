import { useState } from "react";

const Register = () => {
  const [formData, setFormData] = useState({
    name: "",
    email: "",
    password: "",
    confirmPassword: "",
    agree: false,
  });

  const [isLoading, setIsLoading] = useState(false);

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: type === "checkbox" ? checked : value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    setIsLoading(true);

    // Validate đơn giản (bạn có thể custom thêm)
    if (formData.password !== formData.confirmPassword) {
      setIsLoading(false);
      alert("Mật khẩu xác nhận không khớp!");
      return;
    }

    // Giả lập đăng ký
    setTimeout(() => {
      setIsLoading(false);
      alert("Đăng ký thành công!");
    }, 1500);
  };

  return (
    <div className="w-screen flex justify-center">
      <div className="backdrop-blur-md lg:bg-black/10 md:bg-black/10 lg:p-10 md:p-6 rounded-2xl shadow-lg w-80 md:w-96 transition-shadow hover:shadow-2xl hover:shadow-white lg:border-2 md:border-2 border-gray-300/60">
        <form onSubmit={handleSubmit} className="flex flex-col items-center">
          <h2 className="text-4xl text-white font-bold uppercase">Sign up</h2>
          <p className="text-sm text-white mt-3">
            Join us today! Create your account now
          </p>

          <button
            type="button"
            className="w-full mt-8 bg-gray-500/10 flex items-center justify-center h-12 rounded-full"
          >
            <img
              src="https://raw.githubusercontent.com/prebuiltui/prebuiltui/main/assets/login/googleLogo.svg"
              alt="googleLogo"
            />
          </button>

          <div className="flex items-center gap-4 w-full my-5">
            <div className="w-full h-px bg-gray-300/90" />
            <p className="text-sm text-gray-500/90 whitespace-nowrap">
              or sign up with email
            </p>
            <div className="w-full h-px bg-gray-300/90" />
          </div>

          {/* Name */}
          <div className="flex items-center w-full border-2 border-gray-300/60 h-12 rounded-full pl-6 gap-2 bg-transparent">
            <input
              type="text"
              name="name"
              placeholder="Full Name"
              required
              value={formData.name}
              onChange={handleChange}
              className="bg-transparent text-white placeholder-white-300 outline-none text-sm w-full h-full"
            />
          </div>

          {/* Email */}
          <div className="flex items-center w-full mt-6 border-2 border-gray-300/60 h-12 rounded-full pl-6 gap-2 bg-transparent">
            <input
              type="email"
              name="email"
              placeholder="Email"
              required
              value={formData.email}
              onChange={handleChange}
              className="bg-transparent text-white placeholder-white-300 outline-none text-sm w-full h-full"
            />
          </div>

          {/* Password */}
          <div className="flex items-center w-full mt-6 border-2 border-gray-300/60 h-12 rounded-full pl-6 gap-2 bg-transparent">
            <input
              type="password"
              name="password"
              placeholder="Password"
              required
              value={formData.password}
              onChange={handleChange}
              className="bg-transparent text-white placeholder-white-300 outline-none text-sm w-full h-full"
            />
          </div>

          {/* Confirm Password */}
          <div className="flex items-center w-full mt-6 border-2 border-gray-300/60 h-12 rounded-full pl-6 gap-2 bg-transparent">
            <input
              type="password"
              name="confirmPassword"
              placeholder="Confirm Password"
              required
              value={formData.confirmPassword}
              onChange={handleChange}
              className="bg-transparent text-white placeholder-white-300 outline-none text-sm w-full h-full"
            />
          </div>

          {/* Terms & Policy */}
          <div className="w-full flex items-center justify-between mt-8 text-white">
            <div className="flex items-center gap-2">
              <input
                className="h-4 w-4"
                type="checkbox"
                id="agree"
                name="agree"
                checked={formData.agree}
                onChange={handleChange}
                required
              />
              <label className="text-sm" htmlFor="agree">
                I agree to terms
              </label>
            </div>
          </div>

          {/* Submit */}
          <button
            type="submit"
            disabled={isLoading}
            className="mt-8 w-full h-11 rounded-full text-white bg-indigo-500 hover:opacity-90 transition-opacity disabled:opacity-50 disabled:cursor-not-allowed"
          >
            {isLoading ? "Đang tạo tài khoản..." : "Register"}
          </button>

          <p className="text-white text-sm mt-4">
            Already have an account?{" "}
            <a
              className="text-indigo-600 hover:underline cursor-pointer"
              href="/auth/login"
            >
              Sign in
            </a>
          </p>
        </form>
      </div>
    </div>
  );
};

export default Register;
