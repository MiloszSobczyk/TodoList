import axios from "axios";
import { useEffect, useState } from "react";

type FetchState<T> = {
  data: T | null;
  loading: boolean;
  error: string | null;
};

export default function useFetch<T>(url: string) {
  const [fetchState, setFetchState] = useState<FetchState<T>>({
    data: null,
    loading: true,
    error: null,
  });

  useEffect(() => {
    const fetchData = async () => {
      setFetchState({ data: null, loading: true, error: null });
      try {
        const response = await axios.get<T>(url);
        setFetchState({ data: response.data, loading: false, error: null });
      } catch (error) {
        setFetchState({
          data: null,
          loading: false,
          error: "failed to fetch data",
        });
      }
    };
    fetchData();
  }, [url]);
  return fetchState;
}
