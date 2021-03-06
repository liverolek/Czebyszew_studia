// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/greet.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace GrpcGreeter {

  /// <summary>Holder for reflection information generated from Protos/greet.proto</summary>
  public static partial class GreetReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/greet.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static GreetReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChJQcm90b3MvZ3JlZXQucHJvdG8SBWdyZWV0Io8BCgxIZWxsb1JlcXVlc3QS",
            "DgoGbnZhbHVlGAIgASgFEg4KBmh2YWx1ZRgDIAEoARIUCgx3b3JrZXJzQ291",
            "bnQYBCABKAUSFAoMd29ya2VyTnVtYmVyGAUgASgFEg4KBmF2YWx1ZRgGIAEo",
            "ARIOCgZidmFsdWUYByABKAESEwoLc21hbGxOVmFsdWUYCCABKAUiMgoKSGVs",
            "bG9SZXBseRIQCghyZXNwb25zZRgBIAEoARISCgppdGVyYXRpb25zGAIgASgF",
            "Mj0KB0dyZWV0ZXISMgoIU2F5SGVsbG8SEy5ncmVldC5IZWxsb1JlcXVlc3Qa",
            "ES5ncmVldC5IZWxsb1JlcGx5Qg6qAgtHcnBjR3JlZXRlcmIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::GrpcGreeter.HelloRequest), global::GrpcGreeter.HelloRequest.Parser, new[]{ "Nvalue", "Hvalue", "WorkersCount", "WorkerNumber", "Avalue", "Bvalue", "SmallNValue" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::GrpcGreeter.HelloReply), global::GrpcGreeter.HelloReply.Parser, new[]{ "Response", "Iterations" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// The request message containing the user's name.
  /// </summary>
  public sealed partial class HelloRequest : pb::IMessage<HelloRequest>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<HelloRequest> _parser = new pb::MessageParser<HelloRequest>(() => new HelloRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<HelloRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GrpcGreeter.GreetReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HelloRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HelloRequest(HelloRequest other) : this() {
      nvalue_ = other.nvalue_;
      hvalue_ = other.hvalue_;
      workersCount_ = other.workersCount_;
      workerNumber_ = other.workerNumber_;
      avalue_ = other.avalue_;
      bvalue_ = other.bvalue_;
      smallNValue_ = other.smallNValue_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HelloRequest Clone() {
      return new HelloRequest(this);
    }

    /// <summary>Field number for the "nvalue" field.</summary>
    public const int NvalueFieldNumber = 2;
    private int nvalue_;
    /// <summary>
    /// repeated double request = 1;
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Nvalue {
      get { return nvalue_; }
      set {
        nvalue_ = value;
      }
    }

    /// <summary>Field number for the "hvalue" field.</summary>
    public const int HvalueFieldNumber = 3;
    private double hvalue_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Hvalue {
      get { return hvalue_; }
      set {
        hvalue_ = value;
      }
    }

    /// <summary>Field number for the "workersCount" field.</summary>
    public const int WorkersCountFieldNumber = 4;
    private int workersCount_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int WorkersCount {
      get { return workersCount_; }
      set {
        workersCount_ = value;
      }
    }

    /// <summary>Field number for the "workerNumber" field.</summary>
    public const int WorkerNumberFieldNumber = 5;
    private int workerNumber_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int WorkerNumber {
      get { return workerNumber_; }
      set {
        workerNumber_ = value;
      }
    }

    /// <summary>Field number for the "avalue" field.</summary>
    public const int AvalueFieldNumber = 6;
    private double avalue_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Avalue {
      get { return avalue_; }
      set {
        avalue_ = value;
      }
    }

    /// <summary>Field number for the "bvalue" field.</summary>
    public const int BvalueFieldNumber = 7;
    private double bvalue_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Bvalue {
      get { return bvalue_; }
      set {
        bvalue_ = value;
      }
    }

    /// <summary>Field number for the "smallNValue" field.</summary>
    public const int SmallNValueFieldNumber = 8;
    private int smallNValue_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int SmallNValue {
      get { return smallNValue_; }
      set {
        smallNValue_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as HelloRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(HelloRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Nvalue != other.Nvalue) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Hvalue, other.Hvalue)) return false;
      if (WorkersCount != other.WorkersCount) return false;
      if (WorkerNumber != other.WorkerNumber) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Avalue, other.Avalue)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Bvalue, other.Bvalue)) return false;
      if (SmallNValue != other.SmallNValue) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Nvalue != 0) hash ^= Nvalue.GetHashCode();
      if (Hvalue != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Hvalue);
      if (WorkersCount != 0) hash ^= WorkersCount.GetHashCode();
      if (WorkerNumber != 0) hash ^= WorkerNumber.GetHashCode();
      if (Avalue != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Avalue);
      if (Bvalue != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Bvalue);
      if (SmallNValue != 0) hash ^= SmallNValue.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Nvalue != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Nvalue);
      }
      if (Hvalue != 0D) {
        output.WriteRawTag(25);
        output.WriteDouble(Hvalue);
      }
      if (WorkersCount != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(WorkersCount);
      }
      if (WorkerNumber != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(WorkerNumber);
      }
      if (Avalue != 0D) {
        output.WriteRawTag(49);
        output.WriteDouble(Avalue);
      }
      if (Bvalue != 0D) {
        output.WriteRawTag(57);
        output.WriteDouble(Bvalue);
      }
      if (SmallNValue != 0) {
        output.WriteRawTag(64);
        output.WriteInt32(SmallNValue);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Nvalue != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Nvalue);
      }
      if (Hvalue != 0D) {
        output.WriteRawTag(25);
        output.WriteDouble(Hvalue);
      }
      if (WorkersCount != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(WorkersCount);
      }
      if (WorkerNumber != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(WorkerNumber);
      }
      if (Avalue != 0D) {
        output.WriteRawTag(49);
        output.WriteDouble(Avalue);
      }
      if (Bvalue != 0D) {
        output.WriteRawTag(57);
        output.WriteDouble(Bvalue);
      }
      if (SmallNValue != 0) {
        output.WriteRawTag(64);
        output.WriteInt32(SmallNValue);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Nvalue != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Nvalue);
      }
      if (Hvalue != 0D) {
        size += 1 + 8;
      }
      if (WorkersCount != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(WorkersCount);
      }
      if (WorkerNumber != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(WorkerNumber);
      }
      if (Avalue != 0D) {
        size += 1 + 8;
      }
      if (Bvalue != 0D) {
        size += 1 + 8;
      }
      if (SmallNValue != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(SmallNValue);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(HelloRequest other) {
      if (other == null) {
        return;
      }
      if (other.Nvalue != 0) {
        Nvalue = other.Nvalue;
      }
      if (other.Hvalue != 0D) {
        Hvalue = other.Hvalue;
      }
      if (other.WorkersCount != 0) {
        WorkersCount = other.WorkersCount;
      }
      if (other.WorkerNumber != 0) {
        WorkerNumber = other.WorkerNumber;
      }
      if (other.Avalue != 0D) {
        Avalue = other.Avalue;
      }
      if (other.Bvalue != 0D) {
        Bvalue = other.Bvalue;
      }
      if (other.SmallNValue != 0) {
        SmallNValue = other.SmallNValue;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 16: {
            Nvalue = input.ReadInt32();
            break;
          }
          case 25: {
            Hvalue = input.ReadDouble();
            break;
          }
          case 32: {
            WorkersCount = input.ReadInt32();
            break;
          }
          case 40: {
            WorkerNumber = input.ReadInt32();
            break;
          }
          case 49: {
            Avalue = input.ReadDouble();
            break;
          }
          case 57: {
            Bvalue = input.ReadDouble();
            break;
          }
          case 64: {
            SmallNValue = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 16: {
            Nvalue = input.ReadInt32();
            break;
          }
          case 25: {
            Hvalue = input.ReadDouble();
            break;
          }
          case 32: {
            WorkersCount = input.ReadInt32();
            break;
          }
          case 40: {
            WorkerNumber = input.ReadInt32();
            break;
          }
          case 49: {
            Avalue = input.ReadDouble();
            break;
          }
          case 57: {
            Bvalue = input.ReadDouble();
            break;
          }
          case 64: {
            SmallNValue = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  /// <summary>
  /// The response message containing the greetings.
  /// </summary>
  public sealed partial class HelloReply : pb::IMessage<HelloReply>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<HelloReply> _parser = new pb::MessageParser<HelloReply>(() => new HelloReply());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<HelloReply> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GrpcGreeter.GreetReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HelloReply() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HelloReply(HelloReply other) : this() {
      response_ = other.response_;
      iterations_ = other.iterations_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HelloReply Clone() {
      return new HelloReply(this);
    }

    /// <summary>Field number for the "response" field.</summary>
    public const int ResponseFieldNumber = 1;
    private double response_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Response {
      get { return response_; }
      set {
        response_ = value;
      }
    }

    /// <summary>Field number for the "iterations" field.</summary>
    public const int IterationsFieldNumber = 2;
    private int iterations_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Iterations {
      get { return iterations_; }
      set {
        iterations_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as HelloReply);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(HelloReply other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Response, other.Response)) return false;
      if (Iterations != other.Iterations) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Response != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Response);
      if (Iterations != 0) hash ^= Iterations.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Response != 0D) {
        output.WriteRawTag(9);
        output.WriteDouble(Response);
      }
      if (Iterations != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Iterations);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Response != 0D) {
        output.WriteRawTag(9);
        output.WriteDouble(Response);
      }
      if (Iterations != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Iterations);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Response != 0D) {
        size += 1 + 8;
      }
      if (Iterations != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Iterations);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(HelloReply other) {
      if (other == null) {
        return;
      }
      if (other.Response != 0D) {
        Response = other.Response;
      }
      if (other.Iterations != 0) {
        Iterations = other.Iterations;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 9: {
            Response = input.ReadDouble();
            break;
          }
          case 16: {
            Iterations = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 9: {
            Response = input.ReadDouble();
            break;
          }
          case 16: {
            Iterations = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
