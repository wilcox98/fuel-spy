import type { AppProps } from "next/app";
import "bootstrap/dist/css/bootstrap.css";
import "leaflet/dist/leaflet.css";
import "../app/custom.css";
export default function App({ Component, pageProps }: AppProps) {
  return <Component {...pageProps} />;
}
