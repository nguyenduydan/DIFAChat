import { Component } from "react";

export class ErrorBoundary extends Component {
  constructor(props) {
    super(props);
    this.state = { hasError: false, error: null };
  }

  static getDerivedStateFromError(error) {
    return { hasError: true, error };
  }

  componentDidCatch(error, errorInfo) {
    console.error("Uncaught error:", error, errorInfo);
  }

  render() {
    if (this.state.hasError) {
      return (
        <div className="flex h-screen items-center justify-center bg-gray-100 px-4 text-center">
          <div className="rounded-xl bg-white p-8 shadow-lg">
            <h1 className="text-2xl font-bold text-red-600 mb-2">
              Đã xảy ra lỗi
            </h1>
            <p className="text-gray-700">
              Xin hãy thử tải lại trang hoặc liên hệ hỗ trợ kỹ thuật.
            </p>
          </div>
        </div>
      );
    }

    return this.props.children;
  }
}
