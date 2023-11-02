using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace Gx
{
    public class GAny : IEquatable<GAny>
    {
        private long _nativePtr;

        public GAny this[object i]
        {
            get => GetItem(i);
            set => SetItem(i, value);
        }

        public GAny(GAny v)
        {
            _nativePtr = GAnyNative.CGAnyCreate(v._nativePtr);
        }

        public GAny(int v)
        {
            _nativePtr = GAnyNative.CGAnyCreateInt32(v);
        }

        public GAny(Int64 v)
        {
            _nativePtr = GAnyNative.CGAnyCreateInt64(v);
        }

        public GAny(float v)
        {
            _nativePtr = GAnyNative.CGAnyCreateFloat(v);
        }

        public GAny(double v)
        {
            _nativePtr = GAnyNative.CGAnyCreateDouble(v);
        }

        public GAny(byte v)
        {
            _nativePtr = GAnyNative.CGAnyCreateInt8(v);
        }

        public GAny(Int16 v)
        {
            _nativePtr = GAnyNative.CGAnyCreateInt16(v);
        }

        public GAny(bool v)
        {
            _nativePtr = GAnyNative.CGAnyCreateBool(v);
        }

        public GAny(string v)
        {
            _nativePtr = GAnyNative.CGAnyCreateString(v);
        }

        public GAny(IntPtr v)
        {
            _nativePtr = GAnyNative.CGAnyCreatePointer(v);
        }

        private GAny()
        {
        }

        ~GAny()
        {
            GAnyNative.CGAnyDestroy(_nativePtr);
        }

        public static GAny Env()
        {
            GAny any = new GAny
            {
                _nativePtr = GAnyNative.CGAnyEnvironment()
            };
            return any;
        }

        public static GAny Env(string packPath)
        {
            GAny env = Env();
            return env.GetItem(packPath);
        }

        public static GAny Create(object v)
        {
            if (v == null)
            {
                return null;
            }

            if (v is int i)
            {
                return new GAny(i);
            }

            if (v is UInt32 ui)
            {
                return new GAny((int) ui);
            }

            if (v is byte b)
            {
                return new GAny(b);
            }

            if (v is Int16 s)
            {
                return new GAny(s);
            }

            if (v is UInt16 us)
            {
                return new GAny((Int16) us);
            }

            if (v is bool bb)
            {
                return new GAny(bb);
            }

            if (v is string str)
            {
                return new GAny(str);
            }

            if (v is float f)
            {
                return new GAny(f);
            }

            if (v is double d)
            {
                return new GAny(d);
            }

            if (v is Int64 l)
            {
                return new GAny(l);
            }

            if (v is UInt64 ul)
            {
                return new GAny((Int64) ul);
            }

            if (v is IntPtr ptr)
            {
                return new GAny(ptr);
            }

            if (v is GAny gany)
            {
                return gany;
            }

            throw new Exception("GAny.Create: unsupported type");
        }

        public static GAny Undefined()
        {
            GAny any = new GAny
            {
                _nativePtr = GAnyNative.CGAnyCreateUndefined()
            };
            return any;
        }

        public static GAny Null()
        {
            GAny any = new GAny
            {
                _nativePtr = GAnyNative.CGAnyCreateNull()
            };
            return any;
        }

        public static GAny Array()
        {
            GAny any = new GAny
            {
                _nativePtr = GAnyNative.CGAnyCreateArray()
            };
            return any;
        }

        public static GAny Array(List<object> array)
        {
            GAny any = new GAny
            {
                _nativePtr = GAnyNative.CGAnyCreateArray()
            };

            foreach (var o in array)
            {
                any.PushBack(o);
            }

            return any;
        }

        public static GAny Object()
        {
            GAny any = new GAny
            {
                _nativePtr = GAnyNative.CGAnyCreateObject()
            };
            return any;
        }

        public static GAny Object(Dictionary<string, object> map)
        {
            GAny any = new GAny
            {
                _nativePtr = GAnyNative.CGAnyCreateObject()
            };

            foreach (var o in map)
            {
                any.SetItem(o.Key, o.Value);
            }

            return any;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public static GAny Function(GAnyNative.GAnyFunction function)
        {
            GAny any = new GAny
            {
                _nativePtr = GAnyNative.Instance.RegisterFunction(function)
            };
            return any;
        }

        public delegate GAny GAnyFuncRt0();

        public delegate GAny GAnyFuncRt1(GAny v0);

        public delegate GAny GAnyFuncRt2(GAny v1, GAny v2);

        public delegate GAny GAnyFuncRt3(GAny v1, GAny v2, GAny v3);

        public delegate GAny GAnyFuncRt4(GAny v1, GAny v2, GAny v3, GAny v4);

        public delegate GAny GAnyFuncRt5(GAny v1, GAny v2, GAny v3, GAny v4, GAny v5);

        public delegate GAny GAnyFuncRt6(GAny v1, GAny v2, GAny v3, GAny v4, GAny v5, GAny v6);

        public delegate GAny GAnyFuncRt7(GAny v1, GAny v2, GAny v3, GAny v4, GAny v5, GAny v6, GAny v7);

        public delegate void GAnyFuncT0();

        public delegate void GAnyFuncT1(GAny v0);

        public delegate void GAnyFuncT2(GAny v1, GAny v2);

        public delegate void GAnyFuncT3(GAny v1, GAny v2, GAny v3);

        public delegate void GAnyFuncT4(GAny v1, GAny v2, GAny v3, GAny v4);

        public delegate void GAnyFuncT5(GAny v1, GAny v2, GAny v3, GAny v4, GAny v5);

        public delegate void GAnyFuncT6(GAny v1, GAny v2, GAny v3, GAny v4, GAny v5, GAny v6);

        public delegate void GAnyFuncT7(GAny v1, GAny v2, GAny v3, GAny v4, GAny v5, GAny v6, GAny v7);

        public static GAny Function(GAnyFuncRt0 function)
        {
            return Function((GAny[] args) => function());
        }

        public static GAny Function(GAnyFuncRt1 function)
        {
            return Function((GAny[] args) => function(args[0]));
        }

        public static GAny Function(GAnyFuncRt2 function)
        {
            return Function((GAny[] args) => function(args[0], args[1]));
        }

        public static GAny Function(GAnyFuncRt3 function)
        {
            return Function((GAny[] args) => function(args[0], args[1], args[2]));
        }

        public static GAny Function(GAnyFuncRt4 function)
        {
            return Function((GAny[] args) => function(args[0], args[1], args[2], args[3]));
        }

        public static GAny Function(GAnyFuncRt5 function)
        {
            return Function((GAny[] args) => function(args[0], args[1], args[2], args[3], args[4]));
        }

        public static GAny Function(GAnyFuncRt6 function)
        {
            return Function((GAny[] args) => function(args[0], args[1], args[2], args[3], args[4], args[5]));
        }

        public static GAny Function(GAnyFuncRt7 function)
        {
            return Function((GAny[] args) => function(args[0], args[1], args[2], args[3], args[4], args[5], args[6]));
        }

        public static GAny Function(GAnyFuncT0 function)
        {
            return Function(delegate(GAny[] args)
            {
                function();
                return Undefined();
            });
        }

        public static GAny Function(GAnyFuncT1 function)
        {
            return Function(delegate(GAny[] args)
            {
                function(args[0]);
                return Undefined();
            });
        }

        public static GAny Function(GAnyFuncT2 function)
        {
            return Function(delegate(GAny[] args)
            {
                function(args[0], args[1]);
                return Undefined();
            });
        }

        public static GAny Function(GAnyFuncT3 function)
        {
            return Function(delegate(GAny[] args)
            {
                function(args[0], args[1], args[2]);
                return Undefined();
            });
        }

        public static GAny Function(GAnyFuncT4 function)
        {
            return Function(delegate(GAny[] args)
            {
                function(args[0], args[1], args[2], args[3]);
                return Undefined();
            });
        }

        public static GAny Function(GAnyFuncT5 function)
        {
            return Function(delegate(GAny[] args)
            {
                function(args[0], args[1], args[2], args[3], args[4]);
                return Undefined();
            });
        }

        public static GAny Function(GAnyFuncT6 function)
        {
            return Function(delegate(GAny[] args)
            {
                function(args[0], args[1], args[2], args[3], args[4], args[5]);
                return Undefined();
            });
        }

        public static GAny Function(GAnyFuncT7 function)
        {
            return Function(delegate(GAny[] args)
            {
                function(args[0], args[1], args[2], args[3], args[4], args[5], args[6]);
                return Undefined();
            });
        }

        public static GAny CreateFromPtr(long anyPtr)
        {
            GAny any = new GAny
            {
                _nativePtr = anyPtr
            };
            return any;
        }

        public long NativePtr()
        {
            return _nativePtr;
        }

        public GAny Clone(int depth)
        {
            GAny any = new GAny
            {
                _nativePtr = GAnyNative.CGAnyClone(_nativePtr)
            };
            return any;
        }

        public string ClassTypeName()
        {
            IntPtr ptr = GAnyNative.CGAnyClassTypeName(_nativePtr);
            string name = Marshal.PtrToStringUTF8(ptr);
            return name;
        }

        public string TypeName()
        {
            IntPtr ptr = GAnyNative.CGAnyTypeName(_nativePtr);
            string name = Marshal.PtrToStringUTF8(ptr);
            return name;
        }

        public int Length()
        {
            return GAnyNative.CGAnyLength(_nativePtr);
        }

        public int Size()
        {
            return GAnyNative.CGAnySize(_nativePtr);
        }

        public bool Is(string typeStr)
        {
            return GAnyNative.CGAnyIs(_nativePtr, typeStr);
        }

        public bool IsUndefined()
        {
            return GAnyNative.CGAnyIsUndefined(_nativePtr);
        }

        public bool IsNull()
        {
            return GAnyNative.CGAnyIsNull(_nativePtr);
        }

        public bool IsFunction()
        {
            return GAnyNative.CGAnyIsFunction(_nativePtr);
        }

        public bool IsClass()
        {
            return GAnyNative.CGAnyIsClass(_nativePtr);
        }

        public bool IsProperty()
        {
            return GAnyNative.CGAnyIsProperty(_nativePtr);
        }

        public bool IsEnum()
        {
            return GAnyNative.CGAnyIsEnum(_nativePtr);
        }

        public bool IsObject()
        {
            return GAnyNative.CGAnyIsObject(_nativePtr);
        }

        public bool IsArray()
        {
            return GAnyNative.CGAnyIsArray(_nativePtr);
        }

        public bool IsString()
        {
            return GAnyNative.CGAnyIsString(_nativePtr);
        }

        public bool IsInt32()
        {
            return GAnyNative.CGAnyIsInt32(_nativePtr);
        }

        public bool IsInt64()
        {
            return GAnyNative.CGAnyIsInt64(_nativePtr);
        }

        public bool IsInt8()
        {
            return GAnyNative.CGAnyIsInt8(_nativePtr);
        }

        public bool IsInt16()
        {
            return GAnyNative.CGAnyIsInt16(_nativePtr);
        }

        public bool IsFloat()
        {
            return GAnyNative.CGAnyIsFloat(_nativePtr);
        }

        public bool IsDouble()
        {
            return GAnyNative.CGAnyIsDouble(_nativePtr);
        }

        public bool IsNumber()
        {
            return GAnyNative.CGAnyIsNumber(_nativePtr);
        }

        public bool IsBoolean()
        {
            return GAnyNative.CGAnyIsBoolean(_nativePtr);
        }

        public bool IsPointer()
        {
            return GAnyNative.CGAnyIsPointer(_nativePtr);
        }

        public bool IsUserObject()
        {
            return GAnyNative.CGAnyIsUserObject(_nativePtr);
        }

        public int ToInt32()
        {
            return GAnyNative.CGAnyToInt32(_nativePtr);
        }

        public Int64 ToInt64()
        {
            return GAnyNative.CGAnyToInt64(_nativePtr);
        }

        public byte ToInt8()
        {
            return GAnyNative.CGAnyToInt8(_nativePtr);
        }

        public Int16 ToInt16()
        {
            return GAnyNative.CGAnyToInt16(_nativePtr);
        }

        public float ToFloat()
        {
            return GAnyNative.CGAnyToFloat(_nativePtr);
        }

        public double ToDouble()
        {
            return GAnyNative.CGAnyToDouble(_nativePtr);
        }

        public bool ToBool()
        {
            return GAnyNative.CGAnyToBool(_nativePtr);
        }

        public override string ToString()
        {
            IntPtr ptr = GAnyNative.CGAnyToString(_nativePtr);
            string str = Marshal.PtrToStringUTF8(ptr);
            GAnyNative.CGAnyFreeString(ptr);
            return str;
        }

        public string ToJsonString(int indent = -1)
        {
            IntPtr ptr = GAnyNative.CGAnyToJsonString(_nativePtr, indent);
            string str = Marshal.PtrToStringUTF8(ptr);
            GAnyNative.CGAnyFreeString(ptr);
            return str;
        }

        public GAny ToObject()
        {
            long retAnyPtr = GAnyNative.CGAnyToObject(_nativePtr);
            GAny any = new GAny
            {
                _nativePtr = retAnyPtr
            };
            return any;
        }

        public static GAny ParseJson(string json)
        {
            long retAnyPtr = GAnyNative.CGAnyParseJson(json);
            GAny any = new GAny
            {
                _nativePtr = retAnyPtr
            };
            return any;
        }

        public IntPtr ToPointer()
        {
            return GAnyNative.CGAnyToPointer(_nativePtr);
        }

        public string Dump()
        {
            IntPtr ptr = GAnyNative.CGAnyDump(_nativePtr);
            string str = Marshal.PtrToStringUTF8(ptr);
            GAnyNative.CGAnyFreeString(ptr);
            return str;
        }

        public string Help()
        {
            return Dump();
        }

        private bool Contains(GAny id)
        {
            return GAnyNative.CGAnyContains(_nativePtr, id._nativePtr);
        }

        public bool Contains(object id)
        {
            return Contains(Create(id));
        }

        private void Erase(GAny id)
        {
            GAnyNative.CGAnyErase(_nativePtr, id._nativePtr);
        }

        public void Erase(object id)
        {
            Erase(Create(id));
        }

        private void PushBack(GAny rh)
        {
            GAnyNative.CGAnyPushBack(_nativePtr, rh._nativePtr);
        }

        public void PushBack(object rh)
        {
            PushBack(Create(rh));
        }

        public void Clear()
        {
            GAnyNative.CGAnyClear(_nativePtr);
        }

        public GAny Iterator()
        {
            long itPtr = GAnyNative.CGAnyIterator(_nativePtr);
            GAny any = new GAny
            {
                _nativePtr = itPtr
            };
            return any;
        }

        public bool HasNext()
        {
            return GAnyNative.CGAnyHasNext(_nativePtr);
        }

        public GAnyIteratorItem Next()
        {
            return new GAnyIteratorItem(new GAny
            {
                _nativePtr = GAnyNative.CGAnyNext(_nativePtr)
            });
        }

        public GAny CallMethod(string method, params GAny[] args)
        {
            List<long> argsPtr = new();
            foreach (var t in args)
            {
                argsPtr.Add(t._nativePtr);
            }

            long retAnyPtr = GAnyNative.CGAnyCallMethod(_nativePtr, method, argsPtr.ToArray(), argsPtr.Count);
            GAny any = new GAny
            {
                _nativePtr = retAnyPtr
            };
            return any;
        }

        public GAny CallMethod(string method, params object[] args)
        {
            List<GAny> argsAny = new();
            foreach (var t in args)
            {
                argsAny.Add(Create(t));
            }

            return CallMethod(method, argsAny.ToArray());
        }

        public GAny CallMethod(string method)
        {
            long retAnyPtr = GAnyNative.CGAnyCallMethod(_nativePtr, method, null, 0);
            GAny any = new GAny
            {
                _nativePtr = retAnyPtr
            };
            return any;
        }

        public GAny Call(params GAny[] args)
        {
            List<long> argsPtr = new();
            foreach (var t in args)
            {
                argsPtr.Add(t._nativePtr);
            }

            long retAnyPtr = GAnyNative.CGAnyCallFunction(_nativePtr, argsPtr.ToArray(), argsPtr.Count);
            GAny any = new GAny
            {
                _nativePtr = retAnyPtr
            };
            return any;
        }

        public GAny Call(params object[] args)
        {
            List<GAny> argsAny = new();
            foreach (var t in args)
            {
                argsAny.Add(Create(t));
            }

            return Call(argsAny.ToArray());
        }

        public GAny Call()
        {
            long retAnyPtr = GAnyNative.CGAnyCallFunction(_nativePtr, null, 0);
            GAny any = new GAny
            {
                _nativePtr = retAnyPtr
            };
            return any;
        }

        public GAny New(params GAny[] args)
        {
            if (IsClass())
            {
                return Call(args);
            }

            throw new Exception("Can only be used for new of class");
        }

        public GAny New(params object[] args)
        {
            if (IsClass())
            {
                return Call(args);
            }

            throw new Exception("Can only be used for new of class");
        }

        public GAny New()
        {
            if (IsClass())
            {
                return Call();
            }

            throw new Exception("Can only be used for new of class");
        }

        public GAny GetItem(GAny i)
        {
            long retAnyPtr = GAnyNative.CGAnyGetItem(_nativePtr, i._nativePtr);
            GAny any = new GAny
            {
                _nativePtr = retAnyPtr
            };
            return any;
        }

        public GAny GetItem(object i)
        {
            return GetItem(Create(i));
        }

        public void SetItem(GAny i, GAny v)
        {
            GAnyNative.CGAnySetItem(_nativePtr, i._nativePtr, v._nativePtr);
        }

        public void SetItem(object i, object v)
        {
            SetItem(Create(i), Create(v));
        }

        public void DelItem(GAny i)
        {
            GAnyNative.CGAnyDelItem(_nativePtr, i._nativePtr);
        }

        public void DelItem(object i)
        {
            DelItem(Create(i));
        }

        public static GAny operator -(GAny any)
        {
            long retAnyPtr = GAnyNative.CGAnyOperatorNeg(any._nativePtr);
            GAny anyRet = new GAny
            {
                _nativePtr = retAnyPtr
            };
            return anyRet;
        }

        public static GAny operator +(GAny lhs, GAny rhs)
        {
            long retAnyPtr = GAnyNative.CGAnyOperatorAdd(lhs._nativePtr, rhs._nativePtr);
            GAny anyRet = new GAny
            {
                _nativePtr = retAnyPtr
            };
            return anyRet;
        }

        public static GAny operator -(GAny lhs, GAny rhs)
        {
            long retAnyPtr = GAnyNative.CGAnyOperatorSub(lhs._nativePtr, rhs._nativePtr);
            GAny anyRet = new GAny
            {
                _nativePtr = retAnyPtr
            };
            return anyRet;
        }

        public static GAny operator *(GAny lhs, GAny rhs)
        {
            long retAnyPtr = GAnyNative.CGAnyOperatorMul(lhs._nativePtr, rhs._nativePtr);
            GAny anyRet = new GAny
            {
                _nativePtr = retAnyPtr
            };
            return anyRet;
        }

        public static GAny operator /(GAny lhs, GAny rhs)
        {
            long retAnyPtr = GAnyNative.CGAnyOperatorDiv(lhs._nativePtr, rhs._nativePtr);
            GAny anyRet = new GAny
            {
                _nativePtr = retAnyPtr
            };
            return anyRet;
        }

        public static GAny operator %(GAny lhs, GAny rhs)
        {
            long retAnyPtr = GAnyNative.CGAnyOperatorMod(lhs._nativePtr, rhs._nativePtr);
            GAny anyRet = new GAny
            {
                _nativePtr = retAnyPtr
            };
            return anyRet;
        }

        public static GAny operator ^(GAny lhs, GAny rhs)
        {
            long retAnyPtr = GAnyNative.CGAnyOperatorBitXor(lhs._nativePtr, rhs._nativePtr);
            GAny anyRet = new GAny
            {
                _nativePtr = retAnyPtr
            };
            return anyRet;
        }

        public static GAny operator |(GAny lhs, GAny rhs)
        {
            long retAnyPtr = GAnyNative.CGAnyOperatorBitOr(lhs._nativePtr, rhs._nativePtr);
            GAny anyRet = new GAny
            {
                _nativePtr = retAnyPtr
            };
            return anyRet;
        }

        public static GAny operator &(GAny lhs, GAny rhs)
        {
            long retAnyPtr = GAnyNative.CGAnyOperatorBitAnd(lhs._nativePtr, rhs._nativePtr);
            GAny anyRet = new GAny
            {
                _nativePtr = retAnyPtr
            };
            return anyRet;
        }

        public static GAny operator ~(GAny v)
        {
            long retAnyPtr = GAnyNative.CGAnyOperatorBitNot(v._nativePtr);
            GAny anyRet = new GAny
            {
                _nativePtr = retAnyPtr
            };
            return anyRet;
        }

        public static bool operator ==(GAny lhs, GAny rhs)
        {
            if (ReferenceEquals(null, lhs) && ReferenceEquals(null, rhs))
            {
                return true;
            }

            if (ReferenceEquals(null, lhs) || ReferenceEquals(null, rhs))
            {
                return false;
            }

            return GAnyNative.CGAnyOperatorEqualTo(lhs._nativePtr, rhs._nativePtr);
        }

        public static bool operator !=(GAny lhs, GAny rhs)
        {
            return !(rhs == lhs);
        }

        public static bool operator <(GAny lhs, GAny rhs)
        {
            return GAnyNative.CGAnyOperatorLessThan(lhs._nativePtr, rhs._nativePtr);
        }

        public static bool operator >(GAny lhs, GAny rhs)
        {
            return !(GAnyNative.CGAnyOperatorEqualTo(lhs._nativePtr, rhs._nativePtr)
                     || GAnyNative.CGAnyOperatorLessThan(lhs._nativePtr, rhs._nativePtr));
        }

        public static bool operator <=(GAny lhs, GAny rhs)
        {
            return GAnyNative.CGAnyOperatorLessThan(lhs._nativePtr, rhs._nativePtr)
                   || GAnyNative.CGAnyOperatorEqualTo(lhs._nativePtr, rhs._nativePtr);
        }

        public static bool operator >=(GAny lhs, GAny rhs)
        {
            return !GAnyNative.CGAnyOperatorLessThan(lhs._nativePtr, rhs._nativePtr);
        }

        public bool Equals(GAny other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(GAny)) return false;
            return Equals((GAny) obj);
        }

        public override int GetHashCode()
        {
            return _nativePtr.GetHashCode();
        }
    }
}